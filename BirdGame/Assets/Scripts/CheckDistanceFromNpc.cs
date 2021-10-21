using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistanceFromNpc : MonoBehaviour
{
    public int dist;
    public int prevDist = 1000;

    public GameObject player;
    public GameObject npc;

    public Phase _phase;

    public AudioSource aud;
    public AudioSource aud2;

    public AudioClip clipOne;
    public AudioClip clipTwo;
    public AudioClip clipThree;
    
    // Update is called once per frame
    void Update()
    {
        var DistV2 = player.GetComponent<TilePosition>().axialCoordinates - npc.GetComponent<TilePosition>().axialCoordinates;
        if (Mathf.Abs(DistV2.x) > Mathf.Abs(DistV2.y))
        {
            dist = (int)Mathf.Abs(DistV2.x);
        }
        else
        {
            dist = (int)Mathf.Abs(DistV2.y);
        }

        if (dist == 1)
        {
            Debug.Log("one");
        }else if (dist == 2)
        {
            Debug.Log("two");
        } else if (dist == 3)
        {
            Debug.Log("three");
        }
        else
        {
            Debug.Log("Yeet");
        }

        if (_phase._dancePhase == Phase.DancePhase.Beats)
        {
            audPlay();
        }
        else
        {
            aud.Stop();
            //aud2.Stop();
        }
        
        if (prevDist != dist)
        {
            if (dist >= 1 && dist <= 3)
            {
                aud.volume = 1;
            }
            else
            {
                aud.volume = 0;
            }
        }

        prevDist = dist;
    }

    void audPlay()
    {
        if (aud.isPlaying == false)
        {
            aud.Play();
            //aud2.Play();
        }
    }
}
