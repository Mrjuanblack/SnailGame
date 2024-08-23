using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GatherMoreFoodGenerator : BaseGenerator, IGenerator
{
    public float BaseFoodGain { get; private set; } = 3;
    public float BaseFoodLoss { get; private set; } = 2;

    private static readonly string genName = "Gather more food";
    private static readonly string genDesc = "Be more efficient when moving, gathering 3 units of food per move. You spend food when moving too, starting with 2 units per move and increasing with distance.";

    // The player starts with 1 of this generator to allow him to get food when moving
    public GatherMoreFoodGenerator() : base(genName, genDesc, 2, 4, 1.095f) { }

    public string GetEffectText()
    {
        return $"Food per move: {this.NumOfGenerators * this.BaseFoodGain - this.BaseFoodLoss}";
    }
}
