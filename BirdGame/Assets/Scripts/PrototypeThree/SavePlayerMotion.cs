using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerMotion : MonoBehaviour
{
    
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
    }

    public List<PlayerMovements> playerMoves;


}
