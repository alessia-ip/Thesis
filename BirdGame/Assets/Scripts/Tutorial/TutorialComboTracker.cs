using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialComboTracker : MonoBehaviour
{
    public List<KeyCode> comboKeys;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            
            //http://answers.unity.com/answers/996043/view.html
            foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    //TODO -> change this to only register if it is ON BEAT
                    //TODO and if it is part of the 'combo' or a recognized key
                    comboKeys.Add(kcode);
                }
            }

        }       
    }
}
