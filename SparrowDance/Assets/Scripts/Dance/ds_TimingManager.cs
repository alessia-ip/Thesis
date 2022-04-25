using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ds_TimingManager : MonoBehaviour
{

    public AudioSource musicSource; //this is the audiosource I'm keeping track of!

    public float dspSongTime; //this is the song time
    public int songBeatsPerMinute; //this is the BPM of the music!
    public float secondsPerBeat; //this is calculated with some math and is how long there is between beats
    public float currentSongPosition = 0; //this is where we are currently in the song, time wise
    public float songPositionInBeats = 0; //this is where we are currently in the song, beat wise (total beats), but as a FLOAT
    //public int previousBeatNumber = 0; //this was for how I was handling time before, which has lag
    public int currentBeatNumber = 0; //this is the current number of beats, but rounded to the correct whole number
    public int fourByFourBeatNumber; //this is the current beat as a 4/4 (1,2,3,4)

    public float secondsToNextBeat; //this is the seconds left between the current beat and the next beat of the song
    
    
    //remove this UI and int when bug is solved
    public Text FourByFourDebug;
    private int countExecutionNumber = 0;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        ds_Service.TimingManagerInGame = this; //this is just to assign this script to the services manager, so other scripts can reference it
    }

    private void Start()
    {
        //we get the dsp time as our base time right off the bat
        dspSongTime = (float)AudioSettings.dspTime;
        
        //then we grab the BPM of the song from the scriptable object with all the dance information
        songBeatsPerMinute = ds_Service.GameManagerInGame.sceneDanceInformation.songBeatsPerMinute;
        
        //we calculate how many seconds each beat is
        secondsPerBeat = 60f / songBeatsPerMinute;
        
        //these are all functions triggered by delegate events in the event manager
        ds_Service.EventManagerInGame._StartDanceSection += TryTriggerBeat; //we trigger the first beat as soon as we enter the dance
        ds_Service.EventManagerInGame._TriggerBeat += TryTriggerBeat; //every beat after should be scheduled, re-triggering this to schedule the next beat when the present beat happens
        
        ds_Service.EventManagerInGame._StartCountdownSection += setSecondsToZero;
        ds_Service.EventManagerInGame._StartCountdownSection += SetBeatsToZero;
        
        secondsToNextBeat = secondsPerBeat;
        
        setSecondsToZero();
    }


    void SetBeatsToZero()
    {
        fourByFourBeatNumber = 0;
    }

    public void Update()
    {
        UpdateSongTime();
        
        
    }

    void setSecondsToZero()
    {
        secondsToNextBeat = 0f;
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
        //secondsToNextBeat = 0.01f;
    }

    public void UpdateBeatCount()
    {

        getSecondsToNextBeat();
        
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.dancing) return;
        
        //previousBeatNumber = currentBeatNumber;

        if (fourByFourBeatNumber < 4)
        {
            fourByFourBeatNumber++;
        } else if (fourByFourBeatNumber == 4)
        {
            fourByFourBeatNumber = 1;
        }

        FourByFourDebug.text = fourByFourBeatNumber.ToString();
        
        ds_Service.EventManagerInGame._TriggerBeat();

        countExecutionNumber++;
        Debug.Log(countExecutionNumber);
    }
    
}
