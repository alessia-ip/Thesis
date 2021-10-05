using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMManager : MonoBehaviour
{
   public int _bpm;
   public int songLengthInSeconds;
   public float secondsPerBeat;

   public int BeatsBeforeReset;
   public float SecondsBeforeReset;
   public float timeElapsed = 0;
   
   public PhaseSwitch _phaseSwitch;
   public Phase currentPhase;

   public bool InvokeTrigger = false;

   public AudioController _audioController;

   public PlayerDanceMovePos _playerDanceMovePos;
   
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
   }
   
   void TrackOnBeat()
   {
      //get the current position in the song
      //Use moduolo
      //0, <0.1, >0.4 is Perfect
      //0.1 - 0.2, 0.3 - 0.4 is Great
   }

   private void Update()
   {
      if (currentPhase._dancePhase == Phase.DancePhase.Beats)
      {
         timeElapsed = timeElapsed + Time.deltaTime;
         if (timeElapsed >= secondsPerBeat)
         {
            _playerDanceMovePos.MovePlayer();
            timeElapsed = 0;
         }
      }
   }

}
