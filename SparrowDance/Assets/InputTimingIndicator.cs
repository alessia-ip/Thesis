using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTimingIndicator : MonoBehaviour
{
    public float maxTime;
    public float timingOne;
    public float timingTwo;

    public Image timingBarOne;
    public Image timingBarTwo;

    public GameObject NumberOne;
    public GameObject NumberTwo;
    public GameObject NumberThree;
    
    // Start is called before the first frame update
    void Start()
    {
        maxTime = ds_Service.TimingManagerInGame.secondsPerBeat;
        timingOne = 0;
        timingTwo = 0;

        ds_Service.EventManagerInGame._TriggerBeat += determineWhichBar;
    }

    void determineWhichBar()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber == 1)
        {
            NumberOne.SetActive(true);
            InvokeRepeating(nameof(updateTimingBarOne), 0, 0.001f);
        } else if (ds_Service.TimingManagerInGame.fourByFourBeatNumber == 2)
        {
            NumberTwo.SetActive(true);
            InvokeRepeating(nameof(updateTimingBarTwo), 0, 0.001f);
        }
        else if (ds_Service.TimingManagerInGame.fourByFourBeatNumber == 3)
        {
            NumberThree.SetActive(true);
        } else if (ds_Service.TimingManagerInGame.fourByFourBeatNumber == 4)
        {
            NumberOne.SetActive(false);
            NumberTwo.SetActive(false);
            NumberThree.SetActive(false);
            CancelInvoke();
            timingOne = 0;
            timingTwo = 0;
            timingBarOne.fillAmount = 0;
            timingBarTwo.fillAmount = 0;
        }
    }
    
    void updateTimingBarOne()
    {
        timingOne = timingOne + Time.deltaTime;
        var newFill = Map(timingOne, 0f, maxTime, 0f, 1f);
        timingBarOne.fillAmount = newFill;
    }
    
    void updateTimingBarTwo()
    {
        timingTwo = timingTwo + Time.deltaTime;
        var newFill = Map(timingTwo, 0f, maxTime, 0f, 1f);
        timingBarTwo.fillAmount = newFill;
    }

    
    public static float Map(float val, float in1, float in2, float out1, float out2)
    {
        return out1 + (val - in1) * (out2 - out1) / (in2 - in1);
    }
}
