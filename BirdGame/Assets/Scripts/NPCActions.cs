using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCActions : MonoBehaviour
{
   public List<string> actionSet;
   public int currentAction = 0;

   private void Start()
   {
      currentAction = -1;
   }

   private void Update()
   {
      if (currentAction == actionSet.Count - 1)
      {
         currentAction = 0;
      }
   }
}
