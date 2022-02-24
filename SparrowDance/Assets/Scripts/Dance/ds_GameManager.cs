using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_GameManager : MonoBehaviour
{

    /*public DanceInformation sceneDanceInformation;*/
    public AudioSource danceSongAudioSource;
    public DanceInfo sceneDanceInformation;

    public enum GameState
    {
        planning,
        countdown,
        dancing
    }

    public GameState currentGameState = GameState.planning;
    public bool isInMenu = false;

    void Awake()
    {
        AudioListener.pause = true;
        ds_Service.GameManagerInGame = this;
        danceSongAudioSource.clip = sceneDanceInformation.baseSong;
    }

    private void Start()
    {
        ds_Service.EventManagerInGame._StartPlanningSection += changeStateToPlanning;
        ds_Service.EventManagerInGame._StartCountdownSection += changeStateToCountdown;
        ds_Service.EventManagerInGame._StartDanceSection += changeStateToDancing;
    }

    public void changeStateToPlanning()
    {
        currentGameState = GameState.planning;
    }

    public void changeStateToCountdown()
    {
        currentGameState = GameState.countdown;
    }

    public void changeStateToDancing()
    {
        currentGameState = GameState.dancing;
    }
    
}
