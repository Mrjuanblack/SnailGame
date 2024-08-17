using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFoodObserver
{
    void NotifyFoodAmountChanged(float newFoodAmount);
}
