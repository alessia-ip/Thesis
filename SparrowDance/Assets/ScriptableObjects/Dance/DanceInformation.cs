using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DanceInformation", menuName = "ScriptableObjects/DanceInfo")]
public class DanceInformation : ScriptableObject
{
    [Header("Song Information")]
    public AudioClip baseSong;
    public int songBeatsPerMinute;
    [Header("Character Information")] 
    public string characterName;
    public CharacterInformation characterInformation;
}
