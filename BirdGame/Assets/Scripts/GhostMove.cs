using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{

   public GridManager gridManager;
   public SurroundingTiles surroundingTiles;
   
   public GameObject ghostChar;
   
   public void oneAway(int direction)
   {
      var currentPos = ghostChar.GetComponent<positionTracker>();
      GameObject tile = null;
      switch (direction)
      {
         
         case 0:
            var north = surroundingTiles.oneAwayTiles[0];
            tile = gridManager.tileArray[(int)north.x, (int)north.y];
            ghostChar.transform.position = tile.transform.position;
            ghostChar.GetComponent<positionTracker>().GridPosition = north;
            return;
         case 1:
            var east = surroundingTiles.oneAwayTiles[1];
            tile = gridManager.tileArray[(int)east.x, (int)east.y];
            ghostChar.transform.position = tile.transform.position;
            ghostChar.GetComponent<positionTracker>().GridPosition = east;
            return;
         case 2:
            var south = surroundingTiles.oneAwayTiles[2];
            tile = gridManager.tileArray[(int)south.x, (int)south.y];
            ghostChar.transform.position = tile.transform.position;
            ghostChar.GetComponent<positionTracker>().GridPosition = south;
            return;
         case 3:
            var west = surroundingTiles.oneAwayTiles[3];
            tile = gridManager.tileArray[(int)west.x, (int)west.y];
            ghostChar.transform.position = tile.transform.position;
            ghostChar.GetComponent<positionTracker>().GridPosition = west;
            return;
      }
   }
   
}
