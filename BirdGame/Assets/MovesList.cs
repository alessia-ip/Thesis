using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesList : MonoBehaviour
{
    
    //This handles the UI work of planning each move

    public MovesPlanned movesPlanned;
    public ExecutableMovesList executableMovesList;

    public void undo()
    {
        movesPlanned.PlannedMoves.RemoveAt(movesPlanned.PlannedMoves.Count - 1);
        movesPlanned.MoveCost.RemoveAt(movesPlanned.MoveCost.Count - 1);
        //remove the last move and the cost in question
        //TODO should only work if there is at least one move in the list
    }
    
    public void MoveOne(int direction)
    {
        switch (direction)
        {
            case 0:
                //North
                //Adding this action to the list of actions - referencing the moves in the other list
                movesPlanned.PlannedMoves.Add(executableMovesList.exeMoveOneNorth);
                return;
            case 1:
                //East
                movesPlanned.PlannedMoves.Add(executableMovesList.exeMoveOneEast);
                return;
            case 2:
                //South
                movesPlanned.PlannedMoves.Add(executableMovesList.exeMoveOneSouth);
                return;
            case 3:
                //West
                movesPlanned.PlannedMoves.Add(executableMovesList.exeMoveOneWest);
                return;
        }
    }

    public void MoveTwo(Vector2 direction)
    {
        
    }

    public void jump()
    {
        
    }

    public void twirl()
    {
        
    }
    
}
