using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerMotion : MonoBehaviour
{

    public GameObject playerGhost;
    
    public enum PlayerMovements
    {
        move,
        jump,
        flourish,
        talk,
        whisper,
        shout
    }

    public void AddMove()
    {
        playerMoves.Add(PlayerMovements.move);
        playerPosition.Add(playerGhost.transform.position);
        tileAxial.Add(playerGhost.GetComponent<TilePosition>().axialCoordinates);
    }

    public List<PlayerMovements> playerMoves;
    public List<Vector2> playerPosition;
    public List<Vector2> tileAxial;


}
