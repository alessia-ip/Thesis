using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase : MonoBehaviour
{
   
   
   public enum DancePhase
   {
      Planning,
      Beats
   }

   public DancePhase _dancePhase;

   public void DancePhaseSwitch(DancePhase newPhase)
   {
      _dancePhase = newPhase;
      if (_dancePhase == DancePhase.Beats)
      {
         
      } else if (_dancePhase == DancePhase.Planning)
      {
      }
   }
   
}
