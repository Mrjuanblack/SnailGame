using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Snail : MonoBehaviour, IFoodObserver, IDistanceObserver
{
    private bool isAlive = true;
    private bool isMoving = false;
    float distance;
    float food;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        this.distance = GameManager.instance.InitialDistance;
        this.food = GameManager.instance.InitialFood;
        this.speed = GameManager.instance.iInitialSpeed;

        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (!isMoving && isAlive)
            {
                StartCoroutine(COMove());
            }
        });

        // Add observers
        GameManager.instance.AddFoodObserver(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator COMove()
    {
        if (!this.isMoving)
        {
            this.isMoving = true;
            if (GameManager.instance.InitialFood <= 0)
            {
                Debug.Log("Tas muerto");
                this.isMoving = false;
                this.isAlive = false;
                yield return null;
            }

            // Se puede mover
            // TODO: Use speed upgrades for this
            yield return new WaitForSeconds((float)(GameManager.instance.DistancePerMove / speed));
            this.UpdateDistance();
            

            // Calculate the food change
            this.UpdateFoodAmount();

            this.isMoving = false;
            this.Print();
        }
        yield return null;
    }


    private void Print()
    {
        Debug.Log($"Distance: {distance}");
        Debug.Log($"Food: {food}");
    }

    private void UpdateFoodAmount()
    {
        // Get the food generator (the player should always start with it), maybe we should put it outside of the list?
        var gatherFoodGen = GameManager.instance.Generators.FirstOrDefault(gen => gen is GatherMoreFoodGenerator) as GatherMoreFoodGenerator;
        this.food += (gatherFoodGen.BaseFoodGain * gatherFoodGen.NumOfGenerators) - (gatherFoodGen.BaseFoodLoss * Mathf.Pow(GameManager.instance.DistanceFoodLoss, distance));
        this.NotifyFoodAmountChanged(this.food);
    }

    private void UpdateDistance()
    {
        this.distance += GameManager.instance.DistancePerMove;
        this.NotifyDistanceChanged(this.distance);
    }


    // Observers logic
    public void NotifyFoodAmountChanged(float newFoodAmount)
    {
        if (newFoodAmount > 15)
        {
            Debug.Log("Something unlocked");
        }        
    }

    public void NotifyDistanceChanged(float newDistance)
    {
        if (newDistance > 1)
        {
            Debug.Log("Distance unlocked something!");
        }
    }
}
