using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGhost : MonoBehaviour
{
    private GameObject clickedTile;

    public GameObject playerGhost;

    public PlayerPathRenderer _playerPathRenderer;
    public SavePlayerMotion _savePlayerMotion;
    
    public GameObject ClickedTile
    {
        get
        {
            return clickedTile;
        }
        set
        {
            clickedTile = value;
            MovePlayerGhost();
            _savePlayerMotion.AddMove();
        }
    }

    void MovePlayerGhost()
    {
        playerGhost.transform.position = clickedTile.transform.position;
        playerGhost.GetComponent<TilePosition>().axialCoordinates = clickedTile.GetComponent<TilePosition>().axialCoordinates;
        _playerPathRenderer.AddPointToPath();
        clickedTile = null;
    }
}
