using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmUITurnOn : MonoBehaviour
{

    public GameObject rhythmCanvas;
    
    // Update is called once per frame
    void Update()
    {
        if (AudioListener.pause)
        {
            rhythmCanvas.SetActive(false);
        }
        else
        {
            rhythmCanvas.SetActive(true);
        }
    }
}
