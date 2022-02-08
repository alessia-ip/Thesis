using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_EmotionTracker : MonoBehaviour
{
    public int playerVibeAmount;
    public int npcVibeAmount;

    private void Start()
    {
        ds_Service.EmotionTrackerInGame = this;
    }

    public void AddVibeAmount()
    {
        
    }
}
