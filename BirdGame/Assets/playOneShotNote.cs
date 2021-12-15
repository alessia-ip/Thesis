using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playOneShotNote : MonoBehaviour
{

    public AudioClip note;
    public AudioSource aud;

    public void playOneShot()
    {
        aud.PlayOneShot(note);
    }
}
