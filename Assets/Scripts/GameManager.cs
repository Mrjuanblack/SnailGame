using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float initialFood = 100;
    [SerializeField] private float initialDistance = 100;
    // m/s
    [SerializeField] private float initialSpeed = 0.00025f;

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

    public float InitialFood { get => initialFood; }
    public float InitialDistance { get => initialDistance; }
    public float iInitialSpeed { get => initialSpeed; }
    public float DistancePerMove { get => distancePerMove; }
    public float DistanceFoodLoss { get => distanceFoodLoss; }
    public uint BaseFoodGain { get => baseFoodGain; }
    public uint BaseFoodLoss { get => baseFoodLoss; }
    public float Gen1InitCost { get => gen1InitCost; }
    public float Gen1MultFactor { get => gen1MultFactor; }
    public float BaseSpeed { get => baseSpeed; }
    public float Gen2InitCost { get => gen2InitCost; }
    public float Gen2MultFactor { get => gen2MultFactor; }

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
}
