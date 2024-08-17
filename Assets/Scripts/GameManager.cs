using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float initialFood = 10;
    [SerializeField] private float initialDistance = 0;
    // m/s
    // [SerializeField] private float initialSpeed = 0.00025f;
    [SerializeField] private float initialSpeed = 0.025f;

    [SerializeField] private float distancePerMove = 0.001f;
    [SerializeField] private float distanceFoodLoss = 1.05f;

    private List<BaseGenerator> generators = new List<BaseGenerator>()
    {
        new GatherMoreFoodGenerator(),
        new SpeedGenerator(),
    };

    public static GameManager instance;

    public float InitialFood { get => initialFood; }
    public float InitialDistance { get => initialDistance; }
    public float iInitialSpeed { get => initialSpeed; }
    public float DistancePerMove { get => distancePerMove; }
    public float DistanceFoodLoss { get => distanceFoodLoss; }
    public List<BaseGenerator> Generators { get => generators; }

    // Observers for unlocking stuff
    private List<IFoodObserver> foodObservers = new List<IFoodObserver>();
    private List<IDistanceObserver> distanceObservers = new List<IDistanceObserver>();

    public void AddFoodObserver(IFoodObserver observer)
    {
        foodObservers.Add(observer);
    }

    public void AddDistanceObserver(IDistanceObserver observer)
    {
        distanceObservers.Add(observer);
    }

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
