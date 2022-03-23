using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChange : MonoBehaviour
{

    public int beatsToChangeAt;
    public int currentBeats;

    public bool changeNeeded;
    
    // Start is called before the first frame update
    void Start()
    {
        resetBeat();
        ds_Service.EventManagerInGame._StartPlanningSection += resetBeat;
        ds_Service.EventManagerInGame._TriggerBeat += IncrementBeat;
        ds_Service.StateChangeInScene = this;
    }

    void resetBeat()
    {
        currentBeats = 0;
        changeNeeded = false;
    }
   
    void IncrementBeat()
    {
        currentBeats++;
        if (currentBeats + 1 == beatsToChangeAt)
        {
            //Invoke(nameof(changeMode), ds_Service.TimingManagerInGame.secondsPerBeat + 0.5f);
            changeNeeded = true;
        }
    }

    public void InvokeMe()
    {
        Invoke(nameof(changeMode), ds_Service.TimingManagerInGame.secondsPerBeat - 0.05f);
    }

    public void changeMode()
    {
        ds_Service.EventManagerInGame._StartPlanningSection();
    }
}
