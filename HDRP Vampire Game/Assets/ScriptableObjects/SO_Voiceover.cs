using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogueScriptableObject", order = 1)]
public class SO_Voiceover : ScriptableObject
{
    
    public string dialogue;
    public AudioClip voiceLine;
    public string timestamps;
}
