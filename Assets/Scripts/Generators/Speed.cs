using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGenerator : BaseGenerator
{
    public float BaseSpeed = 0.00025f;
    public SpeedGenerator() : base(0, 8, 1.5f) { }
}
