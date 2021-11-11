using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDemo : MonoBehaviour
{
    public OnBeat beat;

    // Update is called once per frame
    void Update()
    {
        if (beat.beatNumber == 144)
        {
            SceneManager.LoadScene(1);        
        }
    }
}
