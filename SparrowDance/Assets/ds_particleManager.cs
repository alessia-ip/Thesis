using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_particleManager : MonoBehaviour
{
    public ParticleSystem sparkleParticles;
    public ParticleSystem sweatParticles;

    private void Start()
    {
        ds_Service.ParticlesInScene = this;
    }

    public void PlayParticleEffect(int particleNum)
    {
        switch (particleNum)
        {
            case 0:
                sparkleParticles.Stop();
                sparkleParticles.Play();
                break;
            case 1:
                sweatParticles.Stop();
                sweatParticles.Play();
                break;
        }
    }
    
}
