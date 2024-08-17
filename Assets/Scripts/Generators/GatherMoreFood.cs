using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatherMoreFoodGenerator : BaseGenerator
{
    public float BaseFoodGain { get; private set; } = 3;
    public float BaseFoodLoss { get; private set; } = 2;

    // The player starts with 1 of this generator to allow him to get food when moving
    public GatherMoreFoodGenerator() : base(2, 4, 1.095f) { }
}
