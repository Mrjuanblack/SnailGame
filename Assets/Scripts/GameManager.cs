using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Basic Settings")]
    [SerializeField] private Snail snail;
    [SerializeField] private float initialFood = 10;
    [SerializeField] private float initialDistance = 0;
    // m/s
    // [SerializeField] private float initialSpeed = 0.00025f;
    [SerializeField] private float initialSpeed = 0.025f;

    [SerializeField] private float distancePerMove = 0.001f;
    [SerializeField] private float distanceFoodLoss = 1.05f;

    // UI Elements
    [Header("UI Elements")]
    [Tooltip("GameObject where all the upgrades will be listed")]
    [SerializeField] private GameObject upgradesContainer;
    [Tooltip("Prefab that will be put inside the upgrades list")]
    [SerializeField] private GameObject upgradePrefab;

    private List<BaseGenerator> generators = new List<BaseGenerator>();

    public static GameManager instance;

    public float InitialFood { get => initialFood; }
    public float InitialDistance { get => initialDistance; }
    public float InitialSpeed { get => initialSpeed; }
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
            this.AddGenerator(new GatherMoreFoodGenerator());
            this.AddGenerator(new SpeedGenerator());
        }
        else if (instance != this)
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    public void AddGenerator(BaseGenerator generator)
    {
        this.generators.Add(generator);
        var newGenIndex = this.generators.Count - 1;
        
        var newGenGameObject = Instantiate(upgradePrefab, upgradesContainer.transform);
        var upgradeItem = newGenGameObject.GetComponent<UpgradeItem>();
        upgradeItem.upgradeName.text = this.generators[newGenIndex].Name;
        upgradeItem.upgradeDescription.text = this.generators[newGenIndex].Description;

        upgradeItem.buyText.text = $"Buy {this.generators[newGenIndex].GetCurrentCost():0.00}";

        upgradeItem.upgradeEffectText.text = (this.generators[newGenIndex] as IGenerator).GetEffectText();

        upgradeItem.buyButton.onClick.AddListener(() => {
            if (this.snail.GetFood() >= this.generators[newGenIndex].GetCurrentCost())
            {
                this.snail.UpdateFoodAmount(this.snail.GetFood() - this.generators[newGenIndex].GetCurrentCost());
                var updatedGen = this.generators[newGenIndex];
                updatedGen.AddGenerator(1);
                upgradeItem.upgradeEffectText.text = (updatedGen as IGenerator).GetEffectText();
                upgradeItem.buyText.text = $"Buy {updatedGen.GetCurrentCost():0.00}";

                this.generators[newGenIndex] = updatedGen;
            }
        });
    }
}
