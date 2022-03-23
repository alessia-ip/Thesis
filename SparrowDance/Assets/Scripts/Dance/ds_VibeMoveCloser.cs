using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ds_VibeMoveCloser : MonoBehaviour
{
    public bool thresholdOneCrossed = false;
    public bool thresholdTwoCrossed = false;

    public bool MoveInwardsP = false;
    public bool MoveInwardsN = false;
    
    public ds_NpcMovementController npcMover;
    public ds_PlayerMovementController playerMover;

    private void Start()
    {
        ds_Service.VibeMoveCloserInGame = this;
    }

    private void Update()
    {
        if (ds_Service.GameManagerInGame.sceneDanceInformation.vibe > 50)
        {
            if (!thresholdOneCrossed)
            {
                thresholdOneCrossed = true;
                MoveInwardsP = true;
                MoveInwardsN = true;
                //npcMover.currentDanceRow = ds_NpcMovementController.RowNum.middle;
                //playerMover.currentDanceRow = ds_PlayerMovementController.RowNum.middle;
            }
        }

        if (ds_Service.GameManagerInGame.sceneDanceInformation.vibe > 85)
        {
            if (!thresholdTwoCrossed)
            {
                thresholdTwoCrossed = true;
                MoveInwardsP = true;
                MoveInwardsN = true;
                //npcMover.currentDanceRow = ds_NpcMovementController.RowNum.front;
                //playerMover.currentDanceRow = ds_PlayerMovementController.RowNum.front;
            }
        }
    }
}
