using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialComboTracker : MonoBehaviour
{
    public List<KeyCode> comboKeys;
    public TutorialCounter counter;
    public float currentTime = 0;
    public float beatTime;
    private int numOfBeats = 0;
    private void Start()
    {
        beatTime = counter.threeBeats / 3;
    }

    // Update is called once per frame
    void Update()
    {

        currentTime = Time.deltaTime + currentTime;
        
        //Keyboard combo checker
        if (Input.anyKeyDown)
        {
            //http://answers.unity.com/answers/996043/view.html
            foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    //TODO -> change this to only register if it is ON BEAT
                    //TODO and if it is part of the 'combo' or a recognized key
                    //comboKeys.Add(kcode);
                    checkInput(kcode);
                }
            }
        }

        if (currentTime >= beatTime)
        {
            currentTime = 0;
            numOfBeats++;
            if (numOfBeats == 3)
            {
                if (comboKeys.Count != 0)
                {
                    Debug.Log(comboKeys[comboKeys.Count - 1]);
                }
                //TODO score the final combo 
                numOfBeats = 0;
                comboKeys.Clear();
            }
        }
    }

    void checkInput(KeyCode kInput)
    {
        /*Debug.Log("Current time: " + currentTime);
        Debug.Log("Current time diff from the beat: " + (beatTime - currentTime));*/
        if (currentTime <= 0.15f || beatTime - currentTime <= 0.15f)
        {
            comboKeys.Add(kInput);
        }
    }
    
}
