using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class MovesPlanned : MonoBehaviour
{

    public MovesList movesList;
    public ExecutableMovesList executableMovesList;
    public List<int> MoveCost = new List<int>();
    public List<Action> PlannedMoves = new List<Action>();
    public EnergyMeter energyMeter;
    public int _moveCost;
    public int prevLength = 0;

    public PathLine pathLine;
    public GameObject player;
    public GameObject playerGhost;

   

    private void Update()
    {
        if (MoveCost.Count != prevLength && MoveCost.Count > 0)
        {
            _moveCost = 0;
            for (int i = 0; i < MoveCost.Count; i++)
            {
                _moveCost = _moveCost + MoveCost[i];
            }
            energyMeter.CurrentEnergy = energyMeter.maxEnergy - _moveCost;
            prevLength = MoveCost.Count;
            Debug.Log(PlannedMoves[PlannedMoves.Count-1].Method);
        } 
        else if (MoveCost.Count == 0)
        {
            _moveCost = 0;
            energyMeter.CurrentEnergy = energyMeter.maxEnergy - _moveCost;
        }
    }
    
    //this is the correct syntax to invoke
    //move list will be planned from MOVE LIST
    //move list will be executed from EXECUTABLE MOVES LIST
    //movesList.Invoke(nameof(movesList.jump), 1f);


}
