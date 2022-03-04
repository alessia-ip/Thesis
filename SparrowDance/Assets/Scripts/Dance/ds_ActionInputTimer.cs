using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_ActionInputTimer : MonoBehaviour
{
    public enum TimingScore
    {
        early,
        good,
        great,
        perfect,
        late
    }

    //this script keeps track of if the player's inputs are on time or not
    public int beatNumber; //this is what beat number we want to keep track of
    public float secondsPerBeat;
    public bool currentlyRunning;
    public float elapsedTime = 0;
    public float maxAllowedTime;
    public TimingScore currentScore;
    public float recordOfStartTime;
    private void Start()
    {
        secondsPerBeat = ds_Service.TimingManagerInGame.secondsPerBeat;

        maxAllowedTime = secondsPerBeat + secondsPerBeat / 4;
    }

    public void Update()
    {
        UpdateTheTimeAndScore();
    }

    public void startTracking()
    {
        if (ds_Service.TimingManagerInGame.currentBeatNumber + 1 != beatNumber) return;

        currentlyRunning = true;
        recordOfStartTime = ds_Service.TimingManagerInGame.currentSongPosition;
    }

    public void RecordPlayerInput()
    {
        if (ds_Service.PlayerInputRecord.playerButtonInputs[beatNumber - 1] != 10) return; //if there is already an input, we don't want to overwrite it
        if (!currentlyRunning) return; //we also don't want to start if it's too early. More important for beats 2 and 3
    
    }

    public void UpdateTheTimeAndScore()
    {
        if (!currentlyRunning) return; 
        elapsedTime = ds_Service.TimingManagerInGame.currentSongPosition - recordOfStartTime;

        if (elapsedTime < secondsPerBeat/8*3)
        {
            currentScore = TimingScore.early;
        } else if(elapsedTime >= secondsPerBeat/8*3
        && elapsedTime < secondsPerBeat/8*5)
        {
            
        }
        
    }
    
    public void GetTiming()
    {
        
    }
    
}
