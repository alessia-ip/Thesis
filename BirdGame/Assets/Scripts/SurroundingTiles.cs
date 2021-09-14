using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurroundingTiles : MonoBehaviour
{
    /*
     * Tiles one away from the player are
     * x + 1 , y => East (1)
     * x - 1 , y => West (3)
     * x , y + 1 => South (2)
     * x , y - 1 => North (0)
     */
    
    /*
     * Tiles two away from the player are
     *  x + 2 , y
     *  x - 2 , y
     *  x , y + 2
     *  x , y - 2
     */

    public List<Vector2> oneAwayTiles;
    public List<Vector2> twoAwayTiles;

    public GridManager _gridManager;

    public GameObject playerChar;

    public void getOneAway()
    {
        Vector2 currentPlayerPos = playerChar.GetComponent<positionTracker>().GridPosition;
        oneAwayTiles.Clear();
        var north = new Vector2(currentPlayerPos.x, currentPlayerPos.y - 1);
        var east = new Vector2(currentPlayerPos.x + 1, currentPlayerPos.y);
        var south = new Vector2(currentPlayerPos.x, currentPlayerPos.y + 1);
        var west = new Vector2(currentPlayerPos.x - 1, currentPlayerPos.y);
        oneAwayTiles.Add(north);
        oneAwayTiles.Add(east);
        oneAwayTiles.Add(south);
        oneAwayTiles.Add(west);
        for (int i = 0; i < 4; i++) //this is to check if we fell off the grid anywhere
        {
            if (oneAwayTiles[i].x < 0 || 
                oneAwayTiles[i].y < 0 || 
                oneAwayTiles[i].x > _gridManager.width - 1||
                oneAwayTiles[i].y > _gridManager.height - 1)
            {
                oneAwayTiles[i] = new Vector2(-100, -100);
            }
        }
    } 
    
    public void getTwoAway()
    {
        Vector2 currentPlayerPos = playerChar.GetComponent<positionTracker>().GridPosition;
        twoAwayTiles.Clear();
        var north = new Vector2(currentPlayerPos.x, currentPlayerPos.y - 2);
        var east = new Vector2(currentPlayerPos.x + 2, currentPlayerPos.y);
        var south = new Vector2(currentPlayerPos.x, currentPlayerPos.y + 2);
        var west = new Vector2(currentPlayerPos.x - 2, currentPlayerPos.y);
        twoAwayTiles.Add(north);
        twoAwayTiles.Add(east);
        twoAwayTiles.Add(south);
        twoAwayTiles.Add(west);
        for (int i = 0; i < 4; i++)
        {
            if (twoAwayTiles[i].x < 0 || 
                twoAwayTiles[i].y < 0 || 
                twoAwayTiles[i].x > _gridManager.width - 1 ||
                twoAwayTiles[i].y > _gridManager.height - 1)
            {
                twoAwayTiles[i] = currentPlayerPos;
            }
        }
    }

}
