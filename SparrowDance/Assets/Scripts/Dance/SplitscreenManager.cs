using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitscreenManager : MonoBehaviour
{

    public GameObject splitscreen;
    public Camera NpcCamera;
    public Camera PlayerCamera;

    public Color SpontaneousCol;
    public Color CalmCol;
    public Color PassionateCol;
    public Color EncourageCol;

    public int playerAction1;
    public int playerAction2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ds_Service.EventManagerInGame._TriggerBeat += turnSplitscreenOn;
        ds_Service.EventManagerInGame._TriggerBeat += turnSplitscreenOff;
        ds_Service.EventManagerInGame._StartPlanningSection += turnSplitscreenOffv2;
        ds_Service.EventManagerInGame._endSong += turnSplitscreenOffv2;
        ds_Service.EventManagerInGame._TriggerBeat += updateCameraBackgroundColor;
    }

    
    
    // Update is called once per frame
    void turnSplitscreenOn()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 4) return;
        
        splitscreen.SetActive(true);
    }
    
    void turnSplitscreenOff()
    {

        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 1) return;
        
        
        
        splitscreen.SetActive(false);
    }
    
    void turnSplitscreenOffv2()
    {
        splitscreen.SetActive(false);
    }
    

    private void updateCameraBackgroundColor()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 4) return;
        
        var npcAction = ds_Service.NpcActionsInLevel.currentlySelectedAction;

        switch (npcAction.mainEmotion)
        {
            case DanceActions.emotion.Spontaneous:
                NpcCamera.backgroundColor = SpontaneousCol;
                break;
            case DanceActions.emotion.Calm:
                NpcCamera.backgroundColor = CalmCol;
                break;
            case DanceActions.emotion.Passionate:
                NpcCamera.backgroundColor = PassionateCol;
                break;
            case DanceActions.emotion.Encouraging:
                NpcCamera.backgroundColor = EncourageCol;
                break;
            default:
                NpcCamera.backgroundColor = Color.white;
                break;
        }
        
        playerAction1 = ds_Service.InputRecords.playerButtonInputs[0];
        playerAction2 = ds_Service.InputRecords.playerButtonInputs[1];

        switch (playerAction1)
        {
            case 0:
                PlayerCamera.backgroundColor = SpontaneousCol;
                check2();
                break;
            case 1:
                PlayerCamera.backgroundColor = CalmCol;
                check2();
                break;
            case 2:
                PlayerCamera.backgroundColor = PassionateCol;
                check2();
                break;
            case 3:
                PlayerCamera.backgroundColor = EncourageCol;
                check2();
                break;
            default:
                PlayerCamera.backgroundColor = Color.white;
                break;
        }

    }

    void check2()
    {
        if (playerAction2 != 0 &&
            playerAction2 != 1 &&
            playerAction2 != 2 &&
            playerAction2 != 3)
        {
            PlayerCamera.backgroundColor = Color.white;
        }
    }
    
}
