using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeypressMusic : MonoBehaviour
{

    public AudioClip keypressClip;
    public AudioSource aud;
    
    void Update()
    {
        if (!AudioListener.pause)
        {
            //TODO All of these should be different sounds!!!
            if (Input.GetKeyDown(KeyCode.Q))
            {
                aud.PlayOneShot(keypressClip);
            } else if (Input.GetKeyDown(KeyCode.W))
            {
                aud.PlayOneShot(keypressClip);
            }else if (Input.GetKeyDown(KeyCode.E))
            {
                aud.PlayOneShot(keypressClip);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                aud.PlayOneShot(keypressClip);
            }
        }
    }
}
