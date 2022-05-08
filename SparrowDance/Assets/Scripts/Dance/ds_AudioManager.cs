using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class ds_AudioManager : MonoBehaviour
{
    public AudioSource songCalmAudioSource;
    public AudioSource songExcitedAudioSource;
    public AudioSource songAffectionateAudioSource;
    
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
        ds_Service.EventManagerInGame._StartCountdownSection += setAudioLevels;

        /*ds_Service.EventManagerInGame._StartDanceSection += endCountdown;
        ds_Service.EventManagerInGame._StartDanceSection += PlayDanceMusic;*/

        ds_Service.EventManagerInGame._StartPlanningSection += PauseDanceMusic;
        ds_Service.EventManagerInGame._StartPlanningSection += PlayPauseMusic;
        
    }

    private void Start()
    {
        songCalmAudioSource.time = 0;
    }

    public void PlayDanceMusic()
    {
        songCalmAudioSource.Play();
        songExcitedAudioSource.Play();
        songAffectionateAudioSource.Play();
        AudioListener.pause = false;
    }
    
    public void PauseDanceMusic()
    {
        songCalmAudioSource.Pause();
        songExcitedAudioSource.Pause();
        songAffectionateAudioSource.Pause();
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


    public void setAudioLevels()
    {
        var info = ds_Service.EmotionTrackerInGame.behaviorEmotion;

        switch (info)
        {
            case MoodEnums.MoodTypes.affectionate:
                songAffectionateAudioSource.volume = 1;
                songExcitedAudioSource.volume = 0;
                songCalmAudioSource.volume = 0;
                return;
            case MoodEnums.MoodTypes.excited:
                songAffectionateAudioSource.volume = 0;
                songExcitedAudioSource.volume = 1;
                songCalmAudioSource.volume = 0;
                return;
            case MoodEnums.MoodTypes.content:
                songAffectionateAudioSource.volume = 0;
                songExcitedAudioSource.volume = 0;
                songCalmAudioSource.volume = 1;
                return;
        }

        
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
    
    
}
