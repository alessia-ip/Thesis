using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLineRenderer : MonoBehaviour
{
    public LineRenderer npcLineRend;

    public List<Vector3> npcPoints;

    public NPCDanceInterpreter _npcDanceInterpreter;
    public NPCDancePhase _npcDancePhase;

    public AxialGridManager _gridManager;
    
    public BeatsPlannedFor _beatsPlannedFor;

    public GameObject npc;
    
    private void Start()
    {
        npcPoints = new List<Vector3>();
        NewPointsList();
    }

    public void NewPointsList()
    {
        npcPoints.Clear();
        var startBeat = _npcDancePhase.beatNum;

        var npcVec3 = new Vector3(
            npc.transform.position.x,
            npc.transform.position.y,
            0);
        npcPoints.Add(npcVec3);
        
        for(int i = 0; i < _beatsPlannedFor.BeatsToPlanFor; i++)
        {
            var GridObj = _npcDanceInterpreter._vec2PosList[i + startBeat];
            var GridPos = _gridManager.tileArray[(int)GridObj.x, (int)GridObj.y];
            var NewVec3 = new Vector3(
                GridPos.transform.position.x,
                GridPos.transform.position.y,
                0);
            npcPoints.Add(NewVec3);
        }

        npcLineRend.positionCount = _beatsPlannedFor.BeatsToPlanFor + 1;
        for (int i = 0; i < npcPoints.Count; i++)
        {
            npcLineRend.SetPosition(i, npcPoints[i]);
        }
    }
}
