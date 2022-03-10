using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ds_CompareMoves : MonoBehaviour
{
    public PlayersDanceActions missAction;
    public PlayersDanceActions playerMove;
        
    void Start()
    {
        ds_Service.CompareMovesInScene = this;
        ds_Service.EventManagerInGame._TriggerBeat += compareNpcAndPlayerActions;
    }

    void compareNpcAndPlayerActions()
    {
        if(ds_Service.TimingManagerInGame.fourByFourBeatNumber != 4) return;

        var npcAction = ds_Service.NpcActionsInLevel.currentlySelectedAction;

        var inputOne =
            ds_Service.InputRecords.playerButtonInputs[0];
        var inputTwo =
            ds_Service.InputRecords.playerButtonInputs[1];

        //PlayersDanceActions playerMove = new PlayersDanceActions(); 
        
        if (inputOne == 10 || inputTwo == 10)
        {
            playerMove = missAction;
        }
        else
        {
            playerMove = ds_Service.AllPlayerActionsInGame.allPlayerDanceActionCombos[inputOne, inputTwo];
        }
        
        

        if (npcAction.PreferredAction == playerMove)
        {
            npcAction.PreferredEventsToCall.Invoke();
        }
        else if (npcAction.AcceptedActions.Contains(playerMove))
        {
            npcAction.AcceptedEventsToCall.Invoke();
        }
        else
        {
            npcAction.OtherEventsToCall.Invoke();
        }
        
    }
}
