using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_particleManager : MonoBehaviour
{
    public ParticleSystem sparkleParticles;
    public ParticleSystem sweatParticles;
    public ParticleSystem yayParticles;
    
    public ParticleSystem sparkleParticles2;
    public ParticleSystem sweatParticles2;
    public ParticleSystem yayParticles2;

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
                sparkleParticles2.Stop();
                sparkleParticles2.Play();
                break;
            case 1:
                sweatParticles.Stop();
                sweatParticles.Play();
                sweatParticles2.Stop();
                sweatParticles2.Play();
                break;
            case 2:
                yayParticles.Stop();
                yayParticles.Play();
                yayParticles2.Stop();
                yayParticles2.Play();
                break;
                
        }
    }
    
}
