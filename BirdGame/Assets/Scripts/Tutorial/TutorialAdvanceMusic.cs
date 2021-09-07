using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TutorialAdvanceMusic : MonoBehaviour
{
    private float time = 0;
    private bool ready = false;
    const float loopTime = 4.651f;

    public GameObject TcountdownText;
    public Text countdownTexttext;
    
    public GameObject tutorialOne;
    public GameObject tutorialTwo;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            ready = true;
            TcountdownText.SetActive(true);
        }
        
        time = time + Time.deltaTime;
        Debug.Log(time);


        if (time < loopTime / 3)
        {
            countdownTexttext.text = "Three.";
        } else if (time >= loopTime / 3 && time <= loopTime / 3 * 2)
        {
            countdownTexttext.text = "Two.";
        } else 
        {
            countdownTexttext.text = "One.";
        }
        
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
