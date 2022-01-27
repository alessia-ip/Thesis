using System.Collections;
using System.Collections.Generic;
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
}
