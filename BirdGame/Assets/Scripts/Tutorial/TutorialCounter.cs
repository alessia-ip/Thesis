using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialCounter : MonoBehaviour
{
    public float time;
    public Text counter;
    public float threeBeats = 0.772f * 3;
    private float elapsedTime = 0;
    private float songTime = 304.728f;
    
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
