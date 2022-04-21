using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_TimingManager : MonoBehaviour
{

    public AudioSource musicSource;

    public float dspSongTime;
    public float prevDspSongTime = 0;
    public int songBeatsPerMinute;
    public float secondsPerBeat;
    public float currentSongPosition = 0;
    public float songPositionInBeats = 0;
    public int previousBeatNumber = 0;
    public int currentBeatNumber = 0;

    public int fourByFourBeatNumber;

    private bool triggeredTryNextBeat = false;

    public float secondsToNextBeat;

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
        
        ds_Service.EventManagerInGame._StartDanceSection += TryTriggerBeat;
        ds_Service.EventManagerInGame._TriggerBeat += TryTriggerBeat;

        secondsToNextBeat = 0f;
    }


    public void Update()
    {
        UpdateSongTime();
    }

    public void getSecondsToNextBeat()
    {
        secondsToNextBeat =  (songPositionInBeats + 1) * secondsPerBeat - currentSongPosition;
        /*var changeTime = currentSongPosition - prevDspSongTime;
        secondsToNextBeat = secondsToNextBeat + changeTime;
        Debug.Log("Seconds: " + secondsToNextBeat);*/
    }

    public void UpdateSongTime()
    {
        //if the audio listener is paused, we dont need to run this
        //and we escape the function
        if (AudioListener.pause) return;

        
        
        //determine how many seconds since the song started
        currentSongPosition = (float)(AudioSettings.dspTime - dspSongTime);
        
        //determine how many beats since the song started
        songPositionInBeats = currentSongPosition / secondsPerBeat;

        //secondsToNextBeat =  (songPositionInBeats + 1) * secondsPerBeat - currentSongPosition;
        getSecondsToNextBeat();
        
        //we want beat 1 to be first, not beat 0! So we always round up
        currentBeatNumber = Mathf.CeilToInt(songPositionInBeats);

        prevDspSongTime = currentSongPosition;

        //This is the OLD way I was doing it
        /*//if the beat hasn't changed we don't need to do this
        //and we escape the function
        if(currentBeatNumber == previousBeatNumber) return;*/

        //otherwise we update the previous beat number
        /*previousBeatNumber = currentBeatNumber;
        
        UpdateBeatCount();*/

    }

    void TryTriggerBeat()
    {
        
        Invoke(nameof(UpdateBeatCount), secondsToNextBeat);
        secondsToNextBeat = 0;
    }

    public void UpdateBeatCount()
    {

        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.dancing) return;
        
        previousBeatNumber = currentBeatNumber;

        
        fourByFourBeatNumber++;
        if (fourByFourBeatNumber > 4)
        {
            fourByFourBeatNumber = 1;
        }

        ds_Service.EventManagerInGame._TriggerBeat();
    }
    
}
