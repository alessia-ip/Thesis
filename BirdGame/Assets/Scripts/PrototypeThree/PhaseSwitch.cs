using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseSwitch : MonoBehaviour
{
    
    public PlayerPathRenderer _playerPathRenderer;
    public SavePlayerMotion _savePlayerMotion;

    public Phase _phase;
    public AudioController _audioController;
    
    public void SetPlanningPhase()
    {
        _phase.DancePhaseSwitch(Phase.DancePhase.Planning);
        
        _playerPathRenderer.ClearPath();
        _savePlayerMotion.playerMoves.Clear();
        _savePlayerMotion.playerPosition.Clear();
    }

    public void SetDancePhase()
    {
        _phase.DancePhaseSwitch(Phase.DancePhase.Beats);
        _audioController.StartDancePhaseAudio();
    }
    
}
