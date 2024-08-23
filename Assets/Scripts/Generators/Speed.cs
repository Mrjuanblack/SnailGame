using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGenerator : BaseGenerator, IGenerator
{
    public float BaseSpeed { get; private set; } = 0.00025f;

    private static readonly string genName = "More speed";
    private static readonly string genDesc = $"Move faster! Increase speed by 0.00025 m/s";
    public SpeedGenerator() : base(genName, genDesc, 0, 8, 1.5f) { }

    public string GetEffectText()
    {
        return $"Extra speed: {this.BaseSpeed * this.NumOfGenerators}";
    }
}
