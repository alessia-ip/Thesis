using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDanceMovePos : MonoBehaviour
{
    public SavePlayerMotion savePlayerMotion;

    public GameObject player;
    
    public void MovePlayer()
    {
        if (savePlayerMotion.playerPosition.Count > 0)
        {
            Debug.Log("MOTION");
            player.transform.position = savePlayerMotion.playerPosition[0];
            savePlayerMotion.playerPosition.RemoveAt(0);
            player.GetComponent<TilePosition>().axialCoordinates = savePlayerMotion.tileAxial[0];
            savePlayerMotion.tileAxial.RemoveAt(0);
        }
    }
}
