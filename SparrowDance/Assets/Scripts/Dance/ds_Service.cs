using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ds_Service
{
    //This is my services manager script for any scene using the dance mechanic
    //these reference our other scripts
    public static ds_AudioManager AudioManagerInGame;
    public static ds_PlayerCharacterAnimations PlayerCharacterAnimationsInGame;
    public static ds_TimingManager TimingManagerInGame;
    public static ds_GameManager GameManagerInGame;
    public static MoodEnums TypesOfMood;
    public static ds_PlayerInputRecord PlayerInputRecord;
    public static ds_EventManager EventManagerInGame;
    public static ds_EmotionTracker EmotionTrackerInGame;
    public static ds_AllowableActions AllowableActionsInLevel;
    public static ds_npcActionManager NpcActionsInLevel;
        
    public static void Initialize()
    {
        TypesOfMood = new MoodEnums();
    }
}
