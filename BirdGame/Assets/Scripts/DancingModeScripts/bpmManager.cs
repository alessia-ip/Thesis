using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class bpmManager : MonoBehaviour
{
    
    //https://www.gamedeveloper.com/audio/coding-to-the-beat---under-the-hood-of-a-rhythm-game-in-unity

    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource that will play the music.
    public AudioSource musicSource;

    private bool firstBeat = true;

    public int loopNumber = 1;




    public AudioSource PauseMusic;
    
    // Start is called before the first frame update
    void Start(){
        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
        
        //Start the music
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (musicSource.isPlaying == true)
        {
            //determine how many seconds since the song started
            songPosition = (float)(AudioSettings.dspTime - dspSongTime);

            //determine how many beats since the song started
            songPositionInBeats = songPosition / secPerBeat;

        }

        if ((int)songPositionInBeats % 15 == 0 && firstBeat == false)
        {
            AudioListener.pause = true;
            musicSource.Pause();
            firstBeat = true;

            var StartOnBeat = ((int)songPositionInBeats - 1) * secPerBeat;
            musicSource.time = StartOnBeat;
            
            PauseMusic.Play();
            
            
        }
        else if ((int)songPositionInBeats % 15 != 0)
        {
            firstBeat = false;
        }

        if (musicSource.isPlaying == false && Input.GetKeyDown(KeyCode.Space))
        {
            PauseMusic.Pause();
            AudioListener.pause = false;
            musicSource.Play();
        }

        loopNumber = Mathf.CeilToInt(songPositionInBeats / 5) - 1;

        if ((int)songPositionInBeats % 5 == 0 && (int)songPositionInBeats != 0)
        {
            Debug.Log("Reaction: " + (int)songPositionInBeats);
        } else {
            
            Debug.Log("MATH HERE: " + ((int)songPositionInBeats - 5 * loopNumber));
            
            if ((int)songPositionInBeats - 5 * loopNumber == 1)
            {
                Debug.Log("NPC: " + (int)songPositionInBeats);
            }
            else
            {
                Debug.Log("ACTION: " + (int)songPositionInBeats);
            }
        }

    }
}
