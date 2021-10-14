using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseSwitch : MonoBehaviour
{
    
    public PlayerPathRenderer _playerPathRenderer;
    public NPCLineRenderer _npcLineRenderer;
    
    public SavePlayerMotion _savePlayerMotion;
    public UiHideAndShow _uiHideAndShow;
    public BeatsPlannedFor _beatsPlannedFor;
    
    public Phase _phase;
    public AudioController _audioController;
    
    public void SetPlanningPhase()
    {
        _phase.DancePhaseSwitch(Phase.DancePhase.Planning);
        
        _playerPathRenderer.ClearPath();
        _savePlayerMotion.playerMoves.Clear();
        _savePlayerMotion.playerPosition.Clear();
        _uiHideAndShow.DancePhaseUI();
        _beatsPlannedFor.BeatsRemaining = _beatsPlannedFor.BeatsToPlanFor;
        
        _npcLineRenderer.NewPointsList();
    }

    public void SetDancePhase()
    {
        _phase.DancePhaseSwitch(Phase.DancePhase.Beats);
        _audioController.StartDancePhaseAudio();
    }
    
}
