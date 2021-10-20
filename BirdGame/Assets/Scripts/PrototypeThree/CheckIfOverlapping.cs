using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfOverlapping : MonoBehaviour
{

    public GameObject player;
    public GameObject NPC;
    public AudioSource crashAud;
    public AudioClip crashAudClip;
    
    public void CheckOverlap()
    {
        Debug.Log("checking");
        if (player.GetComponent<TilePosition>().axialCoordinates == NPC.GetComponent<TilePosition>().axialCoordinates)
        {
            crashAud.PlayOneShot(crashAudClip);
            Debug.Log("OVERLAP");

        }
    }
}
