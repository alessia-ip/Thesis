using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_PlayerCharacterAnimations : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator npcAnimator;
    
    private void Awake()
    {
        ds_Service.PlayerCharacterAnimationsInGame = this;
        ds_Service.EventManagerInGame._TriggerBeat += triggerAnimations;
    }


    void triggerAnimations()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 4) return;

        var inputOne = ds_Service.InputRecords.playerButtonInputs[0];
        var inputTwo = ds_Service.InputRecords.playerButtonInputs[1];
        var playerMove = ds_Service.AllPlayerActionsInGame.allPlayerDanceActionCombos[inputOne, inputTwo];

        if (playerMove.actionName.ToLower().Contains("wiggle"))
        {
            playerAnimator.SetTrigger("Wiggle");
        } else if (playerMove.actionName.ToLower().Contains("wavey"))
        {
            playerAnimator.SetTrigger("Wavey");
        }else if (playerMove.actionName.ToLower().Contains("foot"))
        {
            playerAnimator.SetTrigger("FootTap");
        }else if (playerMove.actionName.ToLower().Contains("twirl"))
        {
            playerAnimator.SetTrigger("Twirl");
        }else if (playerMove.actionName.ToLower().Contains("leg"))
        {
            playerAnimator.SetTrigger("StretchLeg");
        }else if (playerMove.actionName.ToLower().Contains("point"))
        {
            playerAnimator.SetTrigger("Point");
        }else if (playerMove.actionName.ToLower().Contains("sway"))
        {
            playerAnimator.SetTrigger("Sway");
        }else if (playerMove.actionName.ToLower().Contains("kiss"))
        {
            playerAnimator.SetTrigger("BlowKiss");
        }else if (playerMove.actionName.ToLower().Contains("pose"))
        {
            playerAnimator.SetTrigger("Pose");
        }
        else if (playerMove.actionName.ToLower().Contains("beckon"))
        {
            playerAnimator.SetTrigger("Beckon");
        }

        
        
        Invoke(nameof(ResetAllTriggers), 0.1f);
        
    }
    
    
    //https://forum.unity.com/threads/reset-all-animationtriggers.986225/
    private void ResetAllTriggers(Animator anim)
    {
        foreach (var param in anim.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                anim.ResetTrigger(param.name);
            }
        }
    }
}
