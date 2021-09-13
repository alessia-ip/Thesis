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

    
    private void Update()
    {
        var moveCost = 0;
        for (int i = 0; i < MoveCost.Count; i++)
        {
            moveCost = moveCost + MoveCost[i];
        }

        energyMeter.currentEnergy = energyMeter.maxEnergy - moveCost;
    }
    
    //this is the correct syntax to invoke
    //move list will be planned from MOVE LIST
    //move list will be executed from EXECUTABLE MOVES LIST
    //movesList.Invoke(nameof(movesList.jump), 1f);


}
