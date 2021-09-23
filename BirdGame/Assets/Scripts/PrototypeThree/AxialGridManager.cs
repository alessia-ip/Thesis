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
        tileArray = new GameObject[width * 2 + 1, height * 2 + 1];
        makeGrid();
    }

    void makeGrid()
    {
        var axialOffset = height;
        

        for (int y = -height; y <= height; y++)
        {
            var axialY = y + height;

            for (int x = -width; x <= width; x++)
            {
                var axialX = x + width;

                var HexTile = Instantiate(tilePrefab);
                var tilePosition = new Vector2(0, 0);
                if (y == 0 || Mathf.Abs(y % 2) == 0) //if the y coord is even
                {
                    tilePosition = new Vector2(
                        x * horizontalSpacing + horizontalSpacing/2 * axialOffset,
                        y * verticalSpacing
                        );
                }
                else //if the y coord is odd - DONT CHANGE ME
                {
                    tilePosition = new Vector2(
                        x * horizontalSpacing + horizontalSpacing/2 * axialOffset,
                        y * verticalSpacing
                        );
                }

                HexTile.transform.position = tilePosition;
                //HexTile.gameObject.name = "X:" + x + " | Y:" + y;
                HexTile.gameObject.name = "X:" + axialX + " | Y:" + axialY;
                HexTile.gameObject.transform.parent = level.transform;
                //Debug.Log(axialX + "," + axialY);
                tileArray[axialX, axialY] = HexTile;
            }

            Debug.Log(axialOffset);
            axialOffset++;
        }
    }
}
