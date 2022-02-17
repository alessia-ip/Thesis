using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DanceInfo", menuName = "ScriptableObjects/Dance Info")]
public class DanceInfo : ScriptableObject
{
    [Header("Character Information")]
    public string CharacterName;
    
    [Header("Song Information")]
    public AudioClip baseSong;
    public int songBeatsPerMinute;
    
    [Header("Dance Action Information")]
    public DanceActions[] DanceActionsArray;
    
    [Header("Vibe")]
    public float vibe;
    
    [Header("Positive Emotions")]
    public float excitement;
    public float contentment;
    public float affection;
    
    [Header("Neutral Emotions")]
    public float surprise;
    
    [Header("Negative Emotions")]
    public float nervousness;
    public float frustration;
    public float contempt;
    public float worry;
    public float confusion;
    
    //all of these should be on a scale from 0-100
}
