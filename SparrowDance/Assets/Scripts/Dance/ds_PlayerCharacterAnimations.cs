using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_PlayerCharacterAnimations : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator npcAnimator;

    public PlayersDanceActions missAction;
    
    private void Start()
    {
        ds_Service.PlayerCharacterAnimationsInGame = this;
        ds_Service.EventManagerInGame._TriggerBeat += triggerAnimations;
        ds_Service.EventManagerInGame._endSong += ending;
    }


    void triggerAnimations()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 4) return;

        var inputOne = ds_Service.InputRecords.playerButtonInputs[0];
        var inputTwo = ds_Service.InputRecords.playerButtonInputs[1];
        var playerMove = missAction;
        
        if (inputOne == 10 || inputTwo == 10)
        {
            playerMove = missAction;
            playerAnimator.SetTrigger("Failure");
        }
        else
        {
            playerMove = ds_Service.AllPlayerActionsInGame.allPlayerDanceActionCombos[inputOne, inputTwo];
        }

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

        var npcMove = ds_Service.NpcActionsInLevel.currentlySelectedAction;
        
        if (npcMove.actionName.ToLower().Contains("wiggle"))
        {
            npcAnimator.SetTrigger("Wiggle");
        } else if (npcMove.actionName.ToLower().Contains("wavey"))
        {
            npcAnimator.SetTrigger("Wavey");
        }else if (npcMove.actionName.ToLower().Contains("foot"))
        {
            npcAnimator.SetTrigger("FootTap");
        }else if (npcMove.actionName.ToLower().Contains("twirl"))
        {
            npcAnimator.SetTrigger("Twirl");
        }else if (npcMove.actionName.ToLower().Contains("leg"))
        {
            npcAnimator.SetTrigger("StretchLeg");
        }else if (npcMove.actionName.ToLower().Contains("point"))
        {
            npcAnimator.SetTrigger("Point");
        }else if (npcMove.actionName.ToLower().Contains("sway"))
        {
            npcAnimator.SetTrigger("Sway");
        }else if (npcMove.actionName.ToLower().Contains("kiss"))
        {
            npcAnimator.SetTrigger("BlowKiss");
        }else if (npcMove.actionName.ToLower().Contains("pose"))
        {
            npcAnimator.SetTrigger("Pose");
        }
        else if (npcMove.actionName.ToLower().Contains("beckon"))
        {
            npcAnimator.SetTrigger("Beckon");
        }
        
        Invoke(nameof(Resets), 0.1f);
        
    }

    void Resets()
    {
        ResetAllTriggers(npcAnimator);
        ResetAllTriggers(playerAnimator);
        
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

    private void ending()
    {
        npcAnimator.SetTrigger("Bow");
        playerAnimator.SetTrigger("Bow");
    }
}
