using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCounter : MonoBehaviour
{
    private float time;
    public Text counter;
    const float threeBeats = 2.363f;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (time > threeBeats)
        {
            time = 0;
        }
        else
        {
            time = time + Time.deltaTime;
        }
        
        if(time <= threeBeats / 3)
        {
            counter.text = "One.";
        } else if (threeBeats / 3 < time && time <= threeBeats / 3 * 2)
        {
            counter.text = "Two.";
        }
        else
        {
            counter.text = "Three.";
        }


    }
}
