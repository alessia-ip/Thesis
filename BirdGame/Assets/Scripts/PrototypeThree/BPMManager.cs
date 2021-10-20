using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMManager : MonoBehaviour
{
   public int _bpm;
   public float secondsPerBeat;

   public int BeatsBeforeReset;
   public float SecondsBeforeReset;
   public float timeElapsed = 0;
   
   public PhaseSwitch _phaseSwitch;
   public Phase currentPhase;

   public bool InvokeTrigger = false;

   public AudioController _audioController;

   public PlayerDanceMovePos _playerDanceMovePos;
   public OnBeat _onBeat;

   public NPCDancePhase _npc;

   private bool FirstBeat = false;

   public CheckIfOverlapping _checkIfOverlapping;
   
   private void Start()
   {
      secondsPerBeat = 60f/_bpm;
      SecondsBeforeReset = BeatsBeforeReset * secondsPerBeat;
   }

   public void TrackOveralTime()
   {
      if (currentPhase._dancePhase == Phase.DancePhase.Beats && InvokeTrigger == false)
      {
         Invoke("StopMusic", SecondsBeforeReset);
         InvokeTrigger = true;
      }
   }

   void StopMusic()
   {
      _audioController.StartPlanningPhaseAudio();
      _phaseSwitch.SetPlanningPhase();
      InvokeTrigger = false;
      FirstBeat = false;
   }

   private void Update()
   {
      if (currentPhase._dancePhase == Phase.DancePhase.Beats)
      {
         if (FirstBeat == false)
         {
            _playerDanceMovePos.MovePlayer();
            _npc.MoveToNewPos();
            _onBeat.beatNumber++;
            timeElapsed = 0;
            FirstBeat = true;
            _checkIfOverlapping.CheckOverlap();
         }
         
         timeElapsed = timeElapsed + Time.deltaTime;
         
         if (timeElapsed >= secondsPerBeat)
         {
            _playerDanceMovePos.MovePlayer();
            _npc.MoveToNewPos();
            _onBeat.beatNumber++;
            timeElapsed = 0;
            _checkIfOverlapping.CheckOverlap();
         }
      }
   }

}
