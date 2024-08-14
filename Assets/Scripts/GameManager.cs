using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float food;
    private float distance;
    // m/s
    private float speed;

    private float distancePerMove = 0.001f;
    private float distanceFoodLoss = 1.05f;
    // Generator 1
    private uint baseFoodGain = 3;
    private uint baseFoodLoss = 2;
    private float gen1InitCost = 4;
    private float gen1MultFactor = 1.095f;

    // Generator 2
    private float baseSpeed = 0.00025f;
    private float gen2InitCost = 8;
    private float gen2MultFactor = 1.5f;

    private bool isMoving = false;

    public IEnumerator Move()
    {
        if (!isMoving)
        {
            isMoving = true;
            if (food <= 0)
            {
                Debug.Log("Tas muerto");
                isMoving = false;
                yield return null;
            }

            // Se puede mover
            yield return new WaitForSeconds((float)(distancePerMove/speed));
            distance += distancePerMove;

            food += baseFoodGain - (baseFoodLoss * Mathf.Pow(distanceFoodLoss, distance));

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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
