using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_PlayerInputRecord : MonoBehaviour
{
    public int[] playerButtonInputs = new int[2];

    private bool CanInputOne = false;
    private bool CanInputTwo = false;
    
    private void Start()
    {
        ds_Service.InputRecords = this;
        ds_Service.EventManagerInGame._TriggerBeat += ClearValues;
        ds_Service.EventManagerInGame._StartPlanningSection += ClearValues;
        ds_Service.EventManagerInGame._TriggerBeat += AllowInputOne;
        ds_Service.EventManagerInGame._TriggerBeat += AllowInputTwo;
        ClearValues();
    }

    public void ClearValues()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 1) return;

        //we can't use 0 because 0 is an array value I need
        playerButtonInputs[0] = 10;
        playerButtonInputs[1] = 10;
        ds_Service.DanceIndicatorUpdatorInLevel.updatePlayerIndicator(1, playerButtonInputs[0]);
        ds_Service.DanceIndicatorUpdatorInLevel.updatePlayerIndicator(2, playerButtonInputs[1]);

    }

    void AllowInputOne()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 1) return;
        Invoke(nameof(StartInputOne), ds_Service.TimingManagerInGame.secondsPerBeat/2);
    }
    
    
    void StartInputOne()
    {
        CanInputOne = true;
        Invoke(nameof(StopInputOne), ds_Service.TimingManagerInGame.secondsPerBeat);
    }

    void StopInputOne()
    {
        CanInputOne = false;
    }
    
   
    
    void AllowInputTwo()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 2) return;
        Invoke(nameof(StartInputTwo), ds_Service.TimingManagerInGame.secondsPerBeat/2);
    }
    
    void StartInputTwo()
    {
        CanInputTwo = true;
        Invoke(nameof(StopInputTwo), ds_Service.TimingManagerInGame.secondsPerBeat);
    }

    void StopInputTwo()
    {
        CanInputTwo = false;
    }

    public void InputNewValue(int InputVal)
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber == 4) return;
        
        if (CanInputOne)
        {
            if (playerButtonInputs[0] == 10)
            {
                playerButtonInputs[0] = InputVal;
                ds_Service.DanceIndicatorUpdatorInLevel.updatePlayerIndicator(1, playerButtonInputs[0]);
            }
        } else if (CanInputTwo && !CanInputOne)
        {
            if (playerButtonInputs[1] == 10)
            {
                playerButtonInputs[1] = InputVal;
                ds_Service.DanceIndicatorUpdatorInLevel.updatePlayerIndicator(2, playerButtonInputs[1]);

            }
        }
        
    }
    
    
    
}
