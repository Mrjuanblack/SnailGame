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

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            if (!isMoving)
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
            if (GameManager.instance.Food <= 0)
            {
                Debug.Log("Tas muerto");
                isMoving = false;
                yield return null;
            }

            // Se puede mover
            yield return new WaitForSeconds((float)(GameManager.instance.DistancePerMove / GameManager.instance.Speed));
            GameManager.instance.Distance += GameManager.instance.DistancePerMove;

            GameManager.instance.Food += GameManager.instance.BaseFoodGain - (GameManager.instance.BaseFoodLoss * Mathf.Pow(GameManager.instance.DistanceFoodLoss, GameManager.instance.Distance));

            isMoving = false;
            this.Print();
        }
        yield return null;
    }


    private void Print()
    {
        Debug.Log($"Distancia: {GameManager.instance.Distance}");
        Debug.Log($"Comida: {GameManager.instance.Food}");
    }
}
