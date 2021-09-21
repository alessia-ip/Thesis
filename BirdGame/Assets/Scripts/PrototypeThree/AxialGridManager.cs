    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxialGridManager : MonoBehaviour
{
    public int width;
    public int height;
    
    public GameObject tilePrefab;
    public GameObject level;

    public float horizontalSpacing;
    public float verticalSpacing;
    
    public GameObject [,] tileArray;
    
    // Start is called before the first frame update
    void Start()
    {
        var startX = 0;
        var startY = 0;
        tileArray = new GameObject[width * 2, height * 2];
        makeGrid();
    }

    void makeGrid()
    {
        for (int y = -height; y <= height; y++)
        {
            for (int x = -width; x <= width; x++)
            {
                var HexTile = Instantiate(tilePrefab);
                var tilePosition = new Vector2(0, 0);
                if (y == 0 || Mathf.Abs(y % 2) == 0) //if the y coord is even
                {
                    tilePosition = new Vector2(
                        x * horizontalSpacing,
                        y * verticalSpacing
                        );
                }
                else //if the y coord is odd - DONT CHANGE ME
                {
                    tilePosition = new Vector2(
                        x * horizontalSpacing + horizontalSpacing/2,
                        y * verticalSpacing
                        );
                }

                HexTile.transform.position = tilePosition;
                HexTile.gameObject.name = "X:" + x + " | Y:" + y;
            }
        }
    }
}
