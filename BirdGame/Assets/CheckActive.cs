using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckActive : MonoBehaviour
{
    public SurroundingTiles surroundingTiles;
    public int dir;

    void Awake()
    {
        if (surroundingTiles.oneAwayTiles[dir] == new Vector2(-100, -100))
        {
            this.gameObject.SetActive(false);
        }
    }
}
