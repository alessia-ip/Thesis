using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioOnButtonClick : MonoBehaviour
{
    public AudioClip[] actionSounds;
    public AudioClip[] birdSounds;
    public AudioClip[] otherSounds;

    public AudioSource sfxAud;
    
    private void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Q) ||
                Input.GetKeyDown(KeyCode.W) )
            {
                var sfxNum = Random.Range(0, actionSounds.Length );
                sfxAud.PlayOneShot(actionSounds[sfxNum]);
            } else if ( Input.GetKeyDown(KeyCode.E) ||
                        Input.GetKeyDown(KeyCode.R) )
            {
                var sfxNum = Random.Range(0, birdSounds.Length );
                sfxAud.PlayOneShot(birdSounds[sfxNum]);
            }
            else
            {
                var sfxNum = Random.Range(0, otherSounds.Length );
                sfxAud.PlayOneShot(otherSounds[sfxNum]);
            }
        }
    }
}
