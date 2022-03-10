using System;
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

    public AudioSource metronomeSouce;
    public AudioClip metronomeClip;
    
    void Awake()
    {
        ds_Service.AudioManagerInGame = this;

        ds_Service.EventManagerInGame._StartCountdownSection += PausePauseMusic;
        ds_Service.EventManagerInGame._StartCountdownSection += PlayCountdownMusic;

        /*ds_Service.EventManagerInGame._StartDanceSection += endCountdown;
        ds_Service.EventManagerInGame._StartDanceSection += PlayDanceMusic;*/

        ds_Service.EventManagerInGame._StartPlanningSection += PauseDanceMusic;
        ds_Service.EventManagerInGame._StartPlanningSection += PlayPauseMusic;

        /*ds_Service.EventManagerInGame._TriggerBeat += MetronomeTick;*/
    }

    private void Start()
    {
        songAudioSource.time = 0;
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
        ds_Service.EventManagerInGame._StartDanceSection();
    }

    /*public void MetronomeTick()
    {
        double time = AudioSettings.dspTime + ds_Service.TimingManagerInGame.secondsPerBeat;
        metronomeSouce.PlayScheduled(time);
    }*/
    
    /*public void PlaySFX(AudioClip sfxSound, AudioSource sfxSource)
    {
        
    }*/
    
}
