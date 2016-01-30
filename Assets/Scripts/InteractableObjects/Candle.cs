﻿using UnityEngine;
using System.Collections;

public class Candle : InteractableObject {
    public ParticleSystem fireParticles;

    void Start() {
        base.Start();
        ParticleSystem.EmissionModule emission = fireParticles.emission;
        emission.enabled = false;
    }

    public override void StartConflict()
    {
        base.StartConflict();
        ParticleSystem.EmissionModule emission = fireParticles.emission;
        emission.enabled = true;
    }

    public override void EndConflict()
    {
        base.EndConflict();
        ParticleSystem.EmissionModule emission = fireParticles.emission;
        emission.enabled = false;
    }

}