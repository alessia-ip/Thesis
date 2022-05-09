using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ds_DanceIndicatorUpdate : MonoBehaviour
{

    /*public GameObject npcIndicator;
    public GameObject playerIndicatorOne;
    public GameObject playerIndicatorTwo;*/

    [Header("NPC Indicators To Change to")]
    public GameObject npcIndicatorC;
    public GameObject npcIndicatorS;
    public GameObject npcIndicatorP;
    public GameObject npcIndicatorE;
    
    [Header("Player Indicators To Change to")]
    public GameObject pIndicatorC;
    public GameObject pIndicatorS;
    public GameObject pIndicatorP;
    public GameObject pIndicatorE;
    
    [Header("Player Indicators To Change to 2")]
    public GameObject pIndicatorC2;
    public GameObject pIndicatorS2;
    public GameObject pIndicatorP2;
    public GameObject pIndicatorE2;

    private void Start()
    {
        ds_Service.DanceIndicatorUpdatorInLevel = this;

        ds_Service.EventManagerInGame._StartPlanningSection += ClearIndicators;
        ds_Service.EventManagerInGame._TriggerBeat += ResetIndicators;
    }

    public void ClearIndicators()
    {
        /*playerIndicatorOne.GetComponent<Image>().color = Color.grey;
        playerIndicatorTwo.GetComponent<Image>().color = Color.white;
        npcIndicator.GetComponent<Image>().color = Color.white;*/
        
        npcIndicatorC.SetActive(false);
        npcIndicatorS.SetActive(false);
        npcIndicatorP.SetActive(false);
        npcIndicatorE.SetActive(false);

        pIndicatorC.SetActive(false);
        pIndicatorS.SetActive(false);
        pIndicatorP.SetActive(false);
        pIndicatorE.SetActive(false);

        pIndicatorC2.SetActive(false);
        pIndicatorS2.SetActive(false);
        pIndicatorP2.SetActive(false);
        pIndicatorE2.SetActive(false);
    
    }

    public void ResetIndicators()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 4) return;
        
        npcIndicatorC.SetActive(false);
        npcIndicatorS.SetActive(false);
        npcIndicatorP.SetActive(false);
        npcIndicatorE.SetActive(false);

        pIndicatorC.SetActive(false);
        pIndicatorS.SetActive(false);
        pIndicatorP.SetActive(false);
        pIndicatorE.SetActive(false);

        pIndicatorC2.SetActive(false);
        pIndicatorS2.SetActive(false);
        pIndicatorP2.SetActive(false);
        pIndicatorE2.SetActive(false);
    }
    
    public void updateNPCIndicator()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 1) return;

        switch (ds_Service.NpcActionsInLevel.currentlySelectedAction.mainEmotion)
        {
            case DanceActions.emotion.Calm:
                npcIndicatorC.SetActive(true);
                break;
            case DanceActions.emotion.Spontaneous:
                npcIndicatorS.SetActive(true);
                break;
            case DanceActions.emotion.Passionate:
                npcIndicatorP.SetActive(true);
                break;
            case DanceActions.emotion.Encouraging:
                npcIndicatorE.SetActive(true);
                break;
            default:
                npcIndicatorC.SetActive(true);
                break;
        }
    }

    public void updatePlayerIndicator(int whichIndicator, int value)
    {
        if (whichIndicator == 1)
        {
            switch (value)
            {
                case 0:
                    pIndicatorS.SetActive(true);
                    break;
                case 1:
                    pIndicatorC.SetActive(true);
                    break;
                case 2:
                    pIndicatorP.SetActive(true);
                    break;
                case 3:
                    pIndicatorE.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (value)
            {
                case 0:
                    pIndicatorS2.SetActive(true);
                    break;
                case 1:
                    pIndicatorC2.SetActive(true);
                    break;
                case 2:
                    pIndicatorP2.SetActive(true);
                    break;
                case 3:
                    pIndicatorE2.SetActive(true);
                    break;
            }
        }
    }
}
