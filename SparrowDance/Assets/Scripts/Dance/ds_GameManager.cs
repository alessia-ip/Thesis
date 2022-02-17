using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_GameManager : MonoBehaviour
{

    /*public DanceInformation sceneDanceInformation;*/
    public AudioSource danceSongAudioSource;

    public DanceInfo sceneDanceInformation;

    void Awake()
    {
        AudioListener.pause = true;
        ds_Service.GameManagerInGame = this;
        danceSongAudioSource.clip = sceneDanceInformation.baseSong;
        sceneDanceInformation.DanceActionsArray[0].PreferredReactionEvents();
    }

}
