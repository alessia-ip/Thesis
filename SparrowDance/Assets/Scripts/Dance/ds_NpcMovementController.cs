using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_NpcMovementController : MonoBehaviour
{
    public GameObject[] backPositions;
    public GameObject[] middlePositions;
    public GameObject[] frontPositions;

    public GameObject npc;
    
    bool firstMove = true;
    bool lastMove = false;
    
    public enum RowNum
    {
        back,
        middle,
        front
    }
    
    public RowNum currentDanceRow = RowNum.back;

    public int CurrentNum = 1;
    public int direction = -1;
    
    public Vector3 NewPosition;
    private bool Moving = false;
    
    void Start()
    {
        ds_Service.EventManagerInGame._TriggerBeat += moveToTheBeat;
        ds_Service.EventManagerInGame._StartCountdownSection += resetMovementStart;
    }
    
    private void Update()
    {
        if (Moving)
        {
            moveToNewPosition();
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
       
       if (ds_Service.VibeMoveCloserInGame.MoveInwardsN && firstMove)
       {
           ds_Service.VibeMoveCloserInGame.MoveInwardsN = false;
           //var newishPosition = CurrentNum;
           
           if (ds_Service.VibeMoveCloserInGame.thresholdOneCrossed)
           {
               currentDanceRow = RowNum.middle;
           }
            
           if (ds_Service.VibeMoveCloserInGame.thresholdTwoCrossed)
           {
               currentDanceRow = RowNum.front;
           }
           
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

       Debug.Log("Move NPC");
       
       var newPosition = CurrentNum + direction;
       
       switch (currentDanceRow)
       {
           case RowNum.front:
               //npc.transform.position = frontPositions[newPosition].transform.position;
               NewPosition = frontPositions[newPosition].transform.position;
               Moving = true;
               break;
           case RowNum.middle:
               //npc.transform.position = middlePositions[newPosition].transform.position;
               NewPosition = middlePositions[newPosition].transform.position;
               Moving = true;
               break;
           case RowNum.back:
               //npc.transform.position = backPositions[newPosition].transform.position;
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

       if (Vector3.Distance(npc.transform.position, NewPosition) < 0.001f)
       {
           // Swap the position of the cylinder.
           npc.transform.position = NewPosition;
           Moving = false;
           return;
       }

       npc.transform.position = Vector3.MoveTowards(npc.transform.position, NewPosition, Time.deltaTime * (ds_Service.TimingManagerInGame.secondsPerBeat + 0.1f));
        
   }
}
