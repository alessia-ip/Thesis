using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDancePhase : MonoBehaviour
{
    public NPCDanceInterpreter _interpreter;
    public AxialGridManager _grid;
    
    public GameObject NPC;

    private int beatNum = 0;
    
    public void MoveToNewPos()
    {
        if (_interpreter._vec2PosList.Count - 1 <= beatNum)
        {
            var newGridPos = _interpreter._vec2PosList[beatNum];
            var newPhysicalPosition = _grid.tileArray[(int)newGridPos.x, (int)newGridPos.y].transform.position;
            NPC.transform.position = newPhysicalPosition;
            NPC.GetComponent<TilePosition>().axialCoordinates = newGridPos;
            beatNum++;
        }
    }
}
