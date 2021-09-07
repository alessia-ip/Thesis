using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width;
    public int height;

    public GameObject tilePrefab;
    public GameObject level;
    public GameObject startPos;

    public GameObject [,] tileArray;

    // Start is called before the first frame update
    void Start()
    {
        var startX = startPos.transform.position.x;
        var startY = startPos.transform.position.y;
        tileArray = new GameObject[width, height];
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var tilePosition = new Vector2(
                     startX + x + 0.1f * x,
                     startY - y - 0.1f * y);
                var newTile = Instantiate(tilePrefab);
                newTile.transform.position = tilePosition;
                newTile.transform.parent = level.transform;
                newTile.name = "Tile:" + x + "," + y;
                tileArray[x, y] = newTile;
            }
        }
    }

}
