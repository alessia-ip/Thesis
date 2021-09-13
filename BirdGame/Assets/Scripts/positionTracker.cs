using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionTracker : MonoBehaviour
{
    public int gridX;
    public int gridY;
    public Vector2 gridPosition;

    public Vector2 GridPosition
    {
        get
        {
            return gridPosition;
        } 
        set
        {
            gridPosition = value;
            gridX = (int)gridPosition.x;
            gridY = (int)gridPosition.y;

        }
    }
}
