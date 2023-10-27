using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSettings
{
    public int stepsPerFrame { get; set; } = 1;
    public int width { get; set; } = 128;
    public int height { get; set; } = 128;
    public int numAgents { get; set; } = 1000;
    public Simulation.SpawnMode spawnMode { get; set; }

    public float trailWeight { get; set; } = 10f;
    public float decayRate { get; set; } = .1f;
    public float diffuseRate { get; set; } = 2f;

    public SpeciesSettings[] speciesSettings { get; set; }

    public SlimeSettings()
    {
        spawnMode = Simulation.SpawnMode.RandomCircle;

        SpeciesSettings element1 = new SpeciesSettings();
        element1.moveSpeed = 20f;
        element1.turnSpeed = 10f;
        element1.sensorAngleSpacing = 40f;
        element1.sensorOffsetDst = 5f;
        element1.sensorSize = 2;
        element1.colour = new Color(0f, 0f, 25f, 1f);

        SpeciesSettings element2 = new SpeciesSettings();
        element2.moveSpeed = 10f;
        element2.turnSpeed = 3f;
        element2.sensorAngleSpacing = 30f;
        element2.sensorOffsetDst = 1f;
        element2.sensorSize = 2;
        element2.colour = new Color(1f, 25f, 1f, 1f);


        SpeciesSettings element3 = new SpeciesSettings();
        element3.moveSpeed = 10f;
        element3.turnSpeed = 3f;
        element3.sensorAngleSpacing = 30f;
        element3.sensorOffsetDst = 1f;
        element3.sensorSize = 2;
        element3.colour = new Color(25f, 1f, 1f, 1f);


        speciesSettings = new SpeciesSettings[] { element1, element2, element3};
    }

    public string ToString()
    {
        return "stepsPerFrame: "+stepsPerFrame 
            +", width: "+width
             + ", height: " + height;
    }

}

[System.Serializable]
public struct SpeciesSettings
{
    public float moveSpeed { get; set; }
    public float turnSpeed { get; set; }
    public float sensorAngleSpacing { get; set; }
    public float sensorOffsetDst { get; set; }
    public int sensorSize { get; set; }
    public Color colour { get; set; }

}


