using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ds_playerDirectionDetermination))]
public class ds_PlayerMovementController : MonoBehaviour
{

    private ds_playerDirectionDetermination _directionDetermination;
    
    public GameObject[] backPositions;
    public GameObject[] middlePositions;
    public GameObject[] frontPositions;

    public GameObject player;

    public Vector3 NewPosition;
    
    bool firstMove = true;

    private bool lastMove = false;
    
    public enum RowNum
    {
        back,
        middle,
        front
    }
    
    public RowNum currentDanceRow = RowNum.back;

    public int CurrentNum = 1;
    public int direction = -1;

    private bool Moving = false;
    
    void Start()
    {
        _directionDetermination = this.gameObject.GetComponent<ds_playerDirectionDetermination>();
        ds_Service.EventManagerInGame._TriggerBeat += moveToTheBeat;
        ds_Service.EventManagerInGame._StartCountdownSection += setInitDirection;
        ds_Service.EventManagerInGame._StartCountdownSection += resetMovementStart;
        
    }

    private void Update()
    {
        if (Moving)
        {
            moveToNewPosition();
        }
    }

    void setInitDirection()
    {
        if (_directionDetermination.isWith)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }

    void resetMovementStart()
    {
        firstMove = true;
        lastMove = false;
    }
    
    void  moveToTheBeat()
    {
        if (ds_Service.StateChangeInScene.currentBeats == ds_Service.StateChangeInScene.beatsToChangeAt - 4)
        {
            lastMove = true;
        }
        
        if (lastMove)
        {
            return;
        }
        
        if (ds_Service.VibeMoveCloserInGame.MoveInwardsP && firstMove)
        {
            ds_Service.VibeMoveCloserInGame.MoveInwardsP = false;

            if (ds_Service.VibeMoveCloserInGame.thresholdOneCrossed)
            {
                currentDanceRow = RowNum.middle;
            }
            
            if (ds_Service.VibeMoveCloserInGame.thresholdTwoCrossed)
            {
                currentDanceRow = RowNum.front;
            }
            
            //var newishPosition = CurrentNum;
            switch (currentDanceRow)
            {
                case RowNum.front:
                    //npc.transform.position = frontPositions[newishPosition].transform.position;
                    NewPosition = frontPositions[1].transform.position;
                    Moving = true;
                    break;
                case RowNum.middle:
                    //npc.transform.position = middlePositions[newishPosition].transform.position;
                    NewPosition = middlePositions[1].transform.position;
                    Moving = true;
                    break;
            }
            
        
        }
        
        if (firstMove)
        {
            firstMove = false;
            return;
        }
        
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 1) return;

        Debug.Log("Move Player");
       
        var newPosition = CurrentNum + direction;
        
        switch (currentDanceRow)
        {
            case RowNum.front:
                //player.transform.position = frontPositions[newPosition].transform.position;
                NewPosition = frontPositions[newPosition].transform.position;
                Moving = true;
                break;
            case RowNum.middle:
                //player.transform.position = middlePositions[newPosition].transform.position;
                NewPosition = middlePositions[newPosition].transform.position;
                Moving = true;
                break;
            case RowNum.back:
                //player.transform.position = backPositions[newPosition].transform.position;
                NewPosition = backPositions[newPosition].transform.position;
                Moving = true;
                break;
        }
       
        CurrentNum = newPosition;
       
        if (newPosition == 0 || newPosition == 2)
        {
            direction = direction * -1;
        }
    }

    void moveToNewPosition()
    {
        Debug.Log("Slide");

        if (Vector3.Distance(player.transform.position, NewPosition) < 0.001f)
        {
            // Swap the position of the cylinder.
            player.transform.position = NewPosition;
            Moving = false;
            return;
        }

        player.transform.position = Vector3.MoveTowards(player.transform.position, NewPosition, Time.deltaTime * (ds_Service.TimingManagerInGame.secondsPerBeat + 0.1f));
        
    }
}
