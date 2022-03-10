using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_playParticleEffect : MonoBehaviour
{
    public void PlayParticleEffect(int particleNum)
    {
        ds_Service.ParticlesInScene.PlayParticleEffect(particleNum);
    }
}
