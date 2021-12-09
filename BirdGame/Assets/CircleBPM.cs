using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBPM : MonoBehaviour
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
    
    public int loopNumber = 0;
    
    public AudioSource PauseMusic;

    public float previousBeat;

    public GameObject NPC;
    public GameObject Player;


    public AudioSource countIn;
    public AudioClip countInClip;
    
    private void Awake()
    {
        AudioListener.pause = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
        
        //Start the music
        //musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && AudioListener.pause == true && countIn.isPlaying == false)
        {
            /*AudioListener.pause = false;
            musicSource.Play();
            PauseMusic.Pause();*/
            PauseMusic.Pause();
            countIn.PlayOneShot(countInClip);
            Invoke(nameof(countInDone), secPerBeat * 4);
        }
        
        if (musicSource.isPlaying == true)
        {
            //determine how many seconds since the song started
            songPosition = (float)(AudioSettings.dspTime - dspSongTime);

            //determine how many beats since the song started
            songPositionInBeats = songPosition / secPerBeat;
        }

        var beatInt = Mathf.Ceil(songPositionInBeats);

        Debug.Log(beatInt - (32*loopNumber));

        if (beatInt - (32*loopNumber) == 33)
        {
            AudioListener.pause = true;
            musicSource.Pause();
            PauseMusic.Play();
            loopNumber++;
            return;
        }
        
        if (previousBeat != beatInt && AudioListener.pause == false)
        {
            previousBeat = beatInt;

            //THINGS THAT HAPPEN ON BEAT GO HERE
            
            NPC.GetComponent<MoveAroundCircle>().increment();
            Player.GetComponent<MoveAroundCircle>().increment();

        }
            
       

    }


    void countInDone()
    {
        AudioListener.pause = false;
        musicSource.Play();
        PauseMusic.Pause();
    }
    
}
