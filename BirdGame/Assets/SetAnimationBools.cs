using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationBools : MonoBehaviour
{

    public MoveAroundCircle move;
    
    public void isMovingTrue()
    {
        move.IsMoving = true;
    }
    public void isMovingFalse()
    {
        move.IsMoving = false;
    }
    
}
