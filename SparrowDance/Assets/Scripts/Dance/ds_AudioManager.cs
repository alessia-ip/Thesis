using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ds_AudioManager : MonoBehaviour
{
    public AudioSource songAudioSource;
    public AudioSource countdownAudioSource;
    public AudioSource pauseAudioSource;
    public AudioSource sfxAudioSource;
    public float countdownTime;
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
        pauseAudioSource.Play();
    }

    public void PausePauseMusic()
    {
        pauseAudioSource.Stop();
    }

    public void PlayCountdownMusic()
    {
        countdownAudioSource.Play();
        Invoke(nameof(endCountdown), countdownTime);
    }

    public void endCountdown()
    {
        countdownAudioSource.Stop();
        PlayDanceMusic();
    }

    public void PlaySFX(AudioClip sfxSound, AudioSource sfxSource)
    {
        
    }
    
}
