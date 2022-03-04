using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_PlayerInputRecord : MonoBehaviour
{
    public int[] playerButtonInputs = new int[2];

    private void Start()
    {
        ds_Service.InputRecords = this;
        ds_Service.EventManagerInGame._TriggerBeat += ClearValues;
        ds_Service.EventManagerInGame._StartPlanningSection += ClearValues;
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

    public void InputNewValue(int InputVal)
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber == 1 
        || ds_Service.TimingManagerInGame.fourByFourBeatNumber == 4) return;

        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber == 2)
        {
            if (playerButtonInputs[0] == 10)
            {
                playerButtonInputs[0] = InputVal;
                ds_Service.DanceIndicatorUpdatorInLevel.updatePlayerIndicator(1, playerButtonInputs[0]);
            }
        }
        else
        {
            if (playerButtonInputs[1] == 10)
            {
                playerButtonInputs[1] = InputVal;
                ds_Service.DanceIndicatorUpdatorInLevel.updatePlayerIndicator(2, playerButtonInputs[1]);

            }
        }
    }
}
