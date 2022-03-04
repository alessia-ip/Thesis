using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ds_DanceIndicatorUpdate : MonoBehaviour
{

    public GameObject npcIndicator;
    public GameObject playerIndicatorOne;
    public GameObject playerIndicatorTwo;

    public Color tintSpontaneous;
    public Color tintCalm;
    public Color tintPassionate;
    public Color tintEncouraging;

    private void Start()
    {
        ds_Service.DanceIndicatorUpdatorInLevel = this;
    }

    public void updateNPCIndicator()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 1) return;

        switch (ds_Service.NpcActionsInLevel.currentlySelectedAction.mainEmotion)
        {
            case DanceActions.emotion.Calm:
                npcIndicator.GetComponent<Image>().color = tintCalm;
                break;
            case DanceActions.emotion.Spontaneous:
                npcIndicator.GetComponent<Image>().color = tintSpontaneous;
                break;
            case DanceActions.emotion.Passionate:
                npcIndicator.GetComponent<Image>().color = tintPassionate;
                break;
            case DanceActions.emotion.Encouraging:
                npcIndicator.GetComponent<Image>().color = tintEncouraging;
                break;
            default:
                playerIndicatorOne.GetComponent<Image>().color = Color.white;
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
                    playerIndicatorOne.GetComponent<Image>().color = tintSpontaneous;
                    break;
                case 1:
                    playerIndicatorOne.GetComponent<Image>().color = tintCalm;
                    break;
                case 2:
                    playerIndicatorOne.GetComponent<Image>().color = tintPassionate;
                    break;
                case 3:
                    playerIndicatorOne.GetComponent<Image>().color = tintEncouraging;
                    break;
                default:
                    playerIndicatorOne.GetComponent<Image>().color = Color.grey;
                    break;
            }
        }
        else
        {
            switch (value)
            {
                case 0:
                    playerIndicatorTwo.GetComponent<Image>().color = tintSpontaneous;
                    break;
                case 1:
                    playerIndicatorTwo.GetComponent<Image>().color = tintCalm;
                    break;
                case 2:
                    playerIndicatorTwo.GetComponent<Image>().color = tintPassionate;
                    break;
                case 3:
                    playerIndicatorTwo.GetComponent<Image>().color = tintEncouraging;
                    break;
                default:
                    playerIndicatorTwo.GetComponent<Image>().color = Color.white;
                    break;
            }
        }
    }
}
