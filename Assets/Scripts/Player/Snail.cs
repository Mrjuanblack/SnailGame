using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Snail : MonoBehaviour
{
    private bool isAlive = true;
    private bool isMoving = false;
    float distance;
    float food;
    float speed;

    // UI Components
    // TEMP BUTTON while we test.
    // TODO: Clicks on the screen (except on top of ui elements) should trigger the snail to move
    public Button button;
    public TextMeshProUGUI distanceUI;
    public TextMeshProUGUI foodUI;

    // Observer
    SnailObservers observers;


    // Start is called before the first frame update
    void Start()
    {
        this.distance = GameManager.instance.InitialDistance;
        this.food = GameManager.instance.InitialFood;
        this.speed = GameManager.instance.InitialSpeed;

        this.button.onClick.AddListener(() =>
        {
            if (!isMoving && isAlive)
            {
                StartCoroutine(COMove());
            }
        });

        observers = new SnailObservers();

        this.foodUI.text = this.food.ToString("0.00");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator COMove()
    {
        if (!this.isMoving)
        {
            var prevDistance = this.distance;

            this.isMoving = true;
            if (GameManager.instance.InitialFood <= 0)
            {
                Debug.Log("Tas muerto");
                this.isMoving = false;
                this.isAlive = false;
                yield return null;
            }
            
            // Update the distance over time
            float startTime = Time.time;

            // TODO: Test increasing distance per move or speed when the snail is already inside this while loop
            while (Time.time - startTime < (float)(GameManager.instance.DistancePerMove / speed))
            {
                var ellapsedTime = Time.time - startTime;
                this.UpdateDistance(prevDistance + (ellapsedTime * speed));
                yield return null;
            }

            // Fix the distnace precision, since the multiplication with the time won't give the exact distance defined in the game manager
            this.UpdateDistance(prevDistance + GameManager.instance.DistancePerMove);

            // Se puede mover
            // TODO: Use speed upgrades for this
            // yield return new WaitForSeconds((float)(GameManager.instance.DistancePerMove / speed));
            
            

            // Calculate the food change
            // Get the food generator (the player should always start with it), maybe we should put it outside of the list?
            var gatherFoodGen = GameManager.instance.Generators.FirstOrDefault(gen => gen is GatherMoreFoodGenerator) as GatherMoreFoodGenerator;
            var newFoodAmount = this.food + (gatherFoodGen.BaseFoodGain * gatherFoodGen.NumOfGenerators) - (gatherFoodGen.BaseFoodLoss * Mathf.Pow(GameManager.instance.DistanceFoodLoss, distance));
            this.UpdateFoodAmount(newFoodAmount);

            this.isMoving = false;
            this.Print();
        }
        yield return null;
    }

    public float GetFood()
    {
        return this.food;
    }


    private void Print()
    {
        Debug.Log($"Distance: {distance}");
        Debug.Log($"Food: {food}");
    }

    public void UpdateFoodAmount(float newFoodAmount)
    {
        this.food = newFoodAmount;

        // Update UI elements
        this.foodUI.text = this.food.ToString("0.00");

        // Notify observers
        this.observers.NotifyFoodAmountChanged(this.food);
    }

    public void UpdateDistance(float newDistance)
    {
        this.distance = newDistance;

        // Update UI elements
        this.distanceUI.text = this.distance.ToString("0.0000") + " m";

        // Notify observers
        this.observers.NotifyDistanceChanged(this.distance);
    }
}
