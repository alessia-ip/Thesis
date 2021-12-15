using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRhythm : MonoBehaviour
{

    public PlayerComboTracker combo;
    
    public int noteNum = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (noteNum == 3)
        {
            noteNum = 0;
        }
        
        if (!AudioListener.pause)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                combo.buttons[noteNum] = "Q";
            } else if (Input.GetKeyDown(KeyCode.W))
            {
                combo.buttons[noteNum] = "W";
            }else if (Input.GetKeyDown(KeyCode.E))
            {
                combo.buttons[noteNum] = "E";
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                combo.buttons[noteNum] = "R";
            }
        }
    }
}
