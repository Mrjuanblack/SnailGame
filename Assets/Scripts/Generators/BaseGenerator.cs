using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGenerator
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int NumOfGenerators { get; private set; }
    public float InitCost { get; private set; }
    public float MultFactor { get; private set; }

    public BaseGenerator(string name, string description, int numOfGenerators, float initCost, float multFactor)
    {
        this.Name = name;
        this.Description = description;
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
