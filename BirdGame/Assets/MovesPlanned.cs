using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class MovesPlanned : MonoBehaviour
{

    public MovesList movesList;
    public ExecutableMovesList executableMovesList;
    public List<Expression> PlannedMoves = new List<Expression>();
    
    private void Start()
    {
        //this is the correct syntax to invoke
        //move list will be planned from MOVE LIST
        //move list will be executed from EXECUTABLE MOVES LIST
        //movesList.Invoke(nameof(movesList.jump), 1f);
    }
}
