using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBeat : MonoBehaviour
{
    public BPMManager _bpmManager;

    public float currentSongTime;
    public float beatNumber = 1;

    private bool hit = false;


    public AudioSource aud;
    public enum timing
    {
        Perfect,
        Excellent,
        Great,
        Good,
        Miss
    }

    public timing timeRating;
    
    // Update is called once per frame
    void Update()
    {

        currentSongTime = aud.time;

        
        //This only matters when the player checks for it
        
        //take the current beat multiplied by the number of seconds
        //This gives us what the timing SHOULD be in the song
        var perfectTiming = beatNumber * _bpmManager.secondsPerBeat;
        
        //Then we get the player's actual distance away as an always positive number
        var playerTiming = Mathf.Abs(currentSongTime - perfectTiming);

        //Debug.Log("Player time: " + playerTiming);
        
        if (playerTiming == 0)
        {
            timeRating = timing.Perfect;
        }
        else if (playerTiming < 0.1f)
        {
            timeRating = timing.Excellent;
        }
        else if (playerTiming >= 0.1f || playerTiming < 0.2f)
        {
            timeRating = timing.Great;
        } 
        else if (playerTiming >= 0.2f || playerTiming < 0.3f)
        {
            timeRating = timing.Good;
        } else
        {
            timeRating = timing.Miss;
        }

        if (Input.anyKeyDown)
        {
            Debug.Log(timeRating);
        }
        
    }
    
}
