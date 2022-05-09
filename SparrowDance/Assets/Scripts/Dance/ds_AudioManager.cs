using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ds_AudioManager : MonoBehaviour
{
    public AudioSource songCalmAudioSource;
    public AudioSource songExcitedAudioSource;
    public AudioSource songAffectionateAudioSource;

    public AudioSource layerOneAudio;
    public AudioSource layerTwoAudio;
    
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
        var playtime = (ds_Service.TimingManagerInGame.currentBeatNumber) * ds_Service.TimingManagerInGame.secondsPerBeat;
        if (playtime < 0)
        {
            playtime = 0;
        }
        songCalmAudioSource.time = playtime;
        songExcitedAudioSource.time = playtime;
        songAffectionateAudioSource.time = playtime;
        layerOneAudio.time = playtime;
        layerTwoAudio.time = playtime;
        
        songCalmAudioSource.Play();
        songExcitedAudioSource.Play();
        songAffectionateAudioSource.Play();
        
        layerOneAudio.Play();
        layerTwoAudio.Play();
        AudioListener.pause = false;
    }
    
    public void PauseDanceMusic()
    {
        songCalmAudioSource.Pause();
        songExcitedAudioSource.Pause();
        songAffectionateAudioSource.Pause();
        
        layerOneAudio.Pause();
        layerTwoAudio.Pause();
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
                break;
            case MoodEnums.MoodTypes.excited:
                songAffectionateAudioSource.volume = 0;
                songExcitedAudioSource.volume = 1;
                songCalmAudioSource.volume = 0;
                break;
            case MoodEnums.MoodTypes.content:
                songAffectionateAudioSource.volume = 0;
                songExcitedAudioSource.volume = 0;
                songCalmAudioSource.volume = 1;
                break;
        }

        if (ds_Service.VibeMoveCloserInGame.thresholdOneCrossed)
        {
            layerOneAudio.volume = 0.3f;
        }
        else
        {
            layerOneAudio.volume = 0;
        }
        
        if (ds_Service.VibeMoveCloserInGame.thresholdTwoCrossed)
        {
            layerTwoAudio.volume = 0.3f;
        }
        else
        {
            layerTwoAudio.volume = 0;
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
