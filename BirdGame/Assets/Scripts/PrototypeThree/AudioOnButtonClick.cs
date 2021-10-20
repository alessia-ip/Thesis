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

    public GameObject yay;
    
    private void Start()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        yayOff();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Q) ||
                Input.GetKeyDown(KeyCode.W) ||
                Input.GetKeyDown(KeyCode.E))
            {
                var sfxNum = Random.Range(0, actionSounds.Length );
                sfxAud.PlayOneShot(actionSounds[sfxNum]);
                yay.SetActive(true);
                //TODO - move text to another script
                Invoke("yayOff", 0.2f);
            } else if ( Input.GetKeyDown(KeyCode.R))
            {
                var sfxNum = Random.Range(0, birdSounds.Length );
                sfxAud.PlayOneShot(birdSounds[sfxNum]);
            }
        }
    }

    void yayOff()
    {
        yay.SetActive(false);
    }
    
    public void clickHex()
    {
        var sfxNum = Random.Range(0, otherSounds.Length );
        sfxAud.PlayOneShot(otherSounds[sfxNum]);
    }
    
}
