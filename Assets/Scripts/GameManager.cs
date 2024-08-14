using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float food = 100;
    [SerializeField] private float distance = 100;
    // m/s
    [SerializeField] private float speed = 0.00025f;

    [SerializeField] private float distancePerMove = 0.001f;
    [SerializeField] private float distanceFoodLoss = 1.05f;
    // Generator 1
    [SerializeField] private uint baseFoodGain = 3;
    [SerializeField] private uint baseFoodLoss = 2;
    [SerializeField] private float gen1InitCost = 4;
    [SerializeField] private float gen1MultFactor = 1.095f;

    // Generator 2
    [SerializeField] private float baseSpeed = 0.00025f;
    [SerializeField] private float gen2InitCost = 8;
    [SerializeField] private float gen2MultFactor = 1.5f;

    public static GameManager instance;

    public float Food { get => food; set => food = value; }
    public float Distance { get => distance; set => distance = value; }
    public float Speed { get => speed; set => speed = value; }
    public float DistancePerMove { get => distancePerMove; }
    public float DistanceFoodLoss { get => distanceFoodLoss; set => distanceFoodLoss = value; }
    public uint BaseFoodGain { get => baseFoodGain; set => baseFoodGain = value; }
    public uint BaseFoodLoss { get => baseFoodLoss; set => baseFoodLoss = value; }
    public float Gen1InitCost { get => gen1InitCost; set => gen1InitCost = value; }
    public float Gen1MultFactor { get => gen1MultFactor; set => gen1MultFactor = value; }
    public float BaseSpeed { get => baseSpeed; set => baseSpeed = value; }
    public float Gen2InitCost { get => gen2InitCost; set => gen2InitCost = value; }
    public float Gen2MultFactor { get => gen2MultFactor; set => gen2MultFactor = value; }

    //private bool isMoving = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }


    //public void MouseDown()
    //{
    //    if (!isMoving)
    //        StartCoroutine(Move());
    //}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
