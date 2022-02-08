using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInformation", menuName = "ScriptableObjects/CharacterInfo")]
public class CharacterInformation : ScriptableObject
{
    //this is just for NPC characters
    public string name;
    public string relationship;

    public int vibe; //should be a number from 0 - 100 on how in sync you are and how much they open up to you
    
    public List<int> danceRatings = new List<int>();
    
    
    
    

}
