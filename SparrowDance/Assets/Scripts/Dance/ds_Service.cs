using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_Service : MonoBehaviour
{
 
    //This is my services manager script for any scene using the dance mechanic
    
    //these reference our other scripts
    public static ds_AudioManager AudioManagerInGame;
    public static ds_PlayerCharacterAnimations PlayerCharacterAnimationsInGame;
    public static ds_TimingManager TimingManagerInGame;
    public static ds_GameManager GameManagerInGame;
    void Start()
    {
        
    }

}
