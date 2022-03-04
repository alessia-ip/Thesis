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
    
    public enum RowNum
    {
        back,
        middle,
        front
    }
    
    public RowNum currentDanceRow = RowNum.back;

    public int CurrentNum = 1;
    public int direction = -1;
    
    void Start()
    {
        ds_Service.EventManagerInGame._TriggerBeat += moveToTheBeat;
        ds_Service.EventManagerInGame._StartCountdownSection += resetMovementStart;
    }

    void resetMovementStart()
    {
        firstMove = true;
    }
    
   void  moveToTheBeat()
   {
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
               npc.transform.position = frontPositions[newPosition].transform.position;
               break;
           case RowNum.middle:
               npc.transform.position = middlePositions[newPosition].transform.position;
               break;
           case RowNum.back:
               npc.transform.position = backPositions[newPosition].transform.position;
               break;
       }
       
       CurrentNum = newPosition;
       
       if (newPosition == 0 || newPosition == 2)
       {
           direction = direction * -1;
       }
   }
}
