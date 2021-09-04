using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialAdvanceMusic : MonoBehaviour
{
    private float time = 0;
    private bool ready = false;
    const float loopTime = 4.651f;

    public GameObject tutorialOne;
    public GameObject tutorialTwo;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            ready = true;
        }
        
        time = time + Time.deltaTime;
        Debug.Log(time);
        if (time >= loopTime)
        {
            if (ready == false)
            {
                time = 0;
            }
            else
            {
                tutorialTwo.SetActive(true);
                tutorialOne.SetActive(false);
            }
        } 
    }
}
