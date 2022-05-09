using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_EventManager : MonoBehaviour
{
    public delegate void StartDanceSection();
    public StartDanceSection _StartDanceSection;

    public delegate void StartCountdownSection();
    public StartCountdownSection _StartCountdownSection;
    
    public delegate void StartPlanningSection();
    public StartPlanningSection _StartPlanningSection;
    
    public delegate void TriggerBeat();
    public TriggerBeat _TriggerBeat;

    public delegate void VibeMatch();
    public VibeMatch VibeIsMatched;
    
    public delegate void EndOfSong();
    public EndOfSong _endSong;

    private void Awake()
    {
        ds_Service.EventManagerInGame = this;
    }

    void Start()
    {
        _StartPlanningSection += DebugStartPlanning;
        _TriggerBeat += DebugBeat;
        _endSong += EndSongDebug;
        _StartPlanningSection();
    }

    public void EndSongDebug()
    {
        Debug.Log("EndSong");
        ds_Service.GameManagerInGame.currentGameState = ds_GameManager.GameState.end;
    }

    public void DebugStartPlanning()
    {
        Debug.Log("Planning phase begun");
    }
    
    public void DebugBeat()
    {
        Debug.Log("BEAT");
    }
    
}
