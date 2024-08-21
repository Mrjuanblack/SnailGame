using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailObservers : IFoodObserver, IDistanceObserver
{
    public SnailObservers()
    {
        // Add observers
        GameManager.instance.AddFoodObserver(this);
        GameManager.instance.AddDistanceObserver(this);
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
