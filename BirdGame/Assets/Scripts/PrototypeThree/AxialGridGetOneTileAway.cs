using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxialGridGetOneTileAway : MonoBehaviour
{

    public AxialGridManager _axialGrid;
    
    public GameObject player;
    public TilePosition playerPosition;
    
    private Vector2[] directionalCoordinates = new Vector2[6];

    public GameObject[] oneAwayTileList = new GameObject[6];

    public Color blank;
    public Color highlighted;
    
    private void Start()
    {
        playerPosition = player.GetComponent<TilePosition>();

        directionalCoordinates = new Vector2[6];
        directionalCoordinates[0] = new Vector2(-1, 1);
        directionalCoordinates[1] = new Vector2(0, 1);
        directionalCoordinates[2] = new Vector2(1, 0);
        directionalCoordinates[3] = new Vector2(1, -1);
        directionalCoordinates[4] = new Vector2(0, -1);
        directionalCoordinates[5] = new Vector2(-1, 0);

    }

    // Update is called once per frame
    void Update()
    {
        UncolourTiles();
        GetOneAway();
        colourTiles();
    }
    
    /* MATH GRID COORDINATES
     *
     *  North
     *  -1 ,  1
     *   0 ,  1
     * 
     *  East
     *   1 ,  0
     *
     *  South
     *   1 , -1
     *   0 , -1
     *
     *  West
     *  -1 ,  0
     * 
     */

    void UncolourTiles()
    {
        for (int i = 0; i < 6; i++)
        {
            if (oneAwayTileList[i] != null)
            {
                oneAwayTileList[i].GetComponent<SpriteRenderer>().color = blank;
                oneAwayTileList[i].GetComponent<ClickableTile>().clickable = false;
            }
        }
    }
    
    void GetOneAway()
    {
        for (int i = 0; i < 6; i++)
        {
            var newTilePos = playerPosition.axialCoordinates + directionalCoordinates[i];
            GameObject tile = null;
            try
            {
                tile = _axialGrid.tileArray[(int)newTilePos.x, (int)newTilePos.y];
            }
            catch (Exception ex)
            {
                tile = null;
            }
            oneAwayTileList[i] = tile;
        }
    }
    
    void colourTiles()
    {
        for (int i = 0; i < 6; i++)
        {
            if (oneAwayTileList[i] != null)
            {
                oneAwayTileList[i].GetComponent<SpriteRenderer>().color = highlighted;
                oneAwayTileList[i].GetComponent<ClickableTile>().clickable = true;
            }
        }
    }
    
    
}
