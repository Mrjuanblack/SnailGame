using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Snail : MonoBehaviour
{
    private bool isAlive = true;
    private bool isMoving = false;
    float distance = GameManager.instance.InitialDistance;
    float food = GameManager.instance.InitialFood;
    float speed = GameManager.instance.iInitialSpeed;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (!isMoving && isAlive)
            {
                StartCoroutine(COMove());
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator COMove()
    {
        if (!isMoving)
        {
            isMoving = true;
            if (GameManager.instance.InitialFood <= 0)
            {
                Debug.Log("Tas muerto");
                isMoving = false;
                isAlive = false;
                yield return null;
            }

            // Se puede mover
            yield return new WaitForSeconds((float)(GameManager.instance.DistancePerMove / speed));
            distance += GameManager.instance.DistancePerMove;

            food += GameManager.instance.BaseFoodGain - (GameManager.instance.BaseFoodLoss * Mathf.Pow(GameManager.instance.DistanceFoodLoss, distance));

            isMoving = false;
            this.Print();
        }
        yield return null;
    }


    private void Print()
    {
        Debug.Log($"Distancia: {distance}");
        Debug.Log($"Comida: {food}");
    }
}
