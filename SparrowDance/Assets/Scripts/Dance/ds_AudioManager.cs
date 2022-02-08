using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ds_AudioManager : MonoBehaviour
{
    public AudioSource songAudioSource;
    
    void Awake()
    {
        ds_Service.AudioManagerInGame = this;
    }

    public void PlayDanceMusic()
    {
        songAudioSource.Play();
        AudioListener.pause = false;
    }
    
    public void PauseDanceMusic()
    {
        songAudioSource.Pause();
        AudioListener.pause = true;
    }

    public void PlayPauseMusic()
    {
        
    }

    public void PausePauseMusic()
    {
        
    }

    public void PlayCountdownMusic()
    {
        
    }

    public void PlaySFX(AudioClip sfxSound, AudioSource sfxSource)
    {
        
    }
    
}
