using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculateDistance : MonoBehaviour
{


    public GameObject player;
    public GameObject npc;

    private TilePosition playerTile;
    private TilePosition npcTile;


    public int dist;
    
    private void Start()
    {
        playerTile = player.GetComponent<TilePosition>();
        npcTile = npc.GetComponent<TilePosition>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO math
        
    }

}
