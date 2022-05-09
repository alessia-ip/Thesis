using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnding : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (ds_Service.GameManagerInGame.currentGameState == ds_GameManager.GameState.end)
        {
            if (!ds_Service.AudioManagerInGame.songAffectionateAudioSource.isPlaying)
            {
                var checkVibe = ds_Service.GameManagerInGame.sceneDanceInformation.vibe;
                var checkEmotion = ds_Service.EmotionTrackerInGame.baseEmotion;
                
                
            }
        }   
    }
}
