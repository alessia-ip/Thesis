using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_IgnorePausedAudioListener : MonoBehaviour
{
    public AudioSource aud;
    
    // Start is called before the first frame update
    void Start()
    {
        aud.ignoreListenerPause = true;
    }
}
