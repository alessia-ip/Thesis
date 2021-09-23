    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxialGridManager : MonoBehaviour
{
    [Header("Half Grid Size")]
    public int width;
    public int height;
    
    [Header("Level Creator Objects")]
    public GameObject tilePrefab;
    public GameObject level;

    [Header("Spacing Between Hexagonal Tiles")]
    public float horizontalSpacing;
    public float verticalSpacing;
    
    public GameObject [,] tileArray;

    [Header("The Player")]
    public Vector2 playerStartPosition;
    public GameObject player;
    
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
                HexTile.gameObject.name = "X:" + axialX + " | Y:" + axialY;
                
                if (playerStartPosition == new Vector2(axialX, axialY))
                {
                    player.transform.position = HexTile.transform.position;
                    player.GetComponent<TilePosition>().axialCoordinates = new Vector2(axialX, axialY);
                }
                
                HexTile.GetComponent<TilePosition>().axialCoordinates = new Vector2(axialX, axialY);
                HexTile.gameObject.transform.parent = level.transform;
                tileArray[axialX, axialY] = HexTile;

            }
            
            axialOffset++;
        }
    }
}
