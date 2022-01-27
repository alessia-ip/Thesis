using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_TimingManager : MonoBehaviour
{

    public AudioSource musicSource;

    public float dspSongTime;
    public int songBeatsPerMinute;
    public float secondsPerBeat;
    public float currentSongPosition = 0;
    public float songPositionInBeats = 0;
    public int previousBeatNumber = 0;
    public int currentBeatNumber = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        ds_Service.TimingManagerInGame = this;
    }

    private void Start()
    {
        dspSongTime = (float)AudioSettings.dspTime;
        songBeatsPerMinute = ds_Service.GameManagerInGame.sceneDanceInformation.songBeatsPerMinute;
        secondsPerBeat = 60f / songBeatsPerMinute;
    }


    public void Update()
    {
        UpdateSongTime();
    }

    public void UpdateSongTime()
    {
        if (AudioListener.pause) return;
        
        //determine how many seconds since the song started
        currentSongPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats since the song started
        songPositionInBeats = currentSongPosition / secondsPerBeat;

        currentBeatNumber = Mathf.CeilToInt(songPositionInBeats);
        
        if(currentBeatNumber == previousBeatNumber) return;

        previousBeatNumber = currentBeatNumber;
    }
}
