using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGenerator
{
    public int NumOfGenerators { get; private set; }
    public float InitCost { get; private set; }
    public float MultFactor { get; private set; }

    public BaseGenerator(int numOfGenerators, float initCost, float multFactor)
    {
        this.NumOfGenerators = numOfGenerators;
        this.InitCost = initCost;
        this.MultFactor = multFactor;
    }

    public void AddGenerator(int numOfGenToAdd)
    {
        if (numOfGenToAdd > 0)
            NumOfGenerators += numOfGenToAdd;
    }

    public float GetCurrentCost()
    {
        return InitCost * Mathf.Pow(MultFactor, NumOfGenerators);
    }
}
