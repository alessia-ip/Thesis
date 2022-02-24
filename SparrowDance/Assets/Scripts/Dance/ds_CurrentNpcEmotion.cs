using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ds_CurrentNpcEmotion : MonoBehaviour
{
    private MoodEnums.MoodTypes baseEmotion; //this is the general emotion!
    public MoodEnums.MoodTypes behaviorEmotion;  //this is the emotion to currently regard when picking actions
    public MoodEnums.MoodTypes tiebreaker; //if all values are equal, what emotion does this character gravitate towards

    public int worryThreshold;
    
    // Start is called before the first frame update
    void Start()
    {
        ds_Service.EmotionTrackerInGame = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (ds_Service.GameManagerInGame.sceneDanceInformation.excitement >
            ds_Service.GameManagerInGame.sceneDanceInformation.affection)
        {
            if (ds_Service.GameManagerInGame.sceneDanceInformation.excitement >
                ds_Service.GameManagerInGame.sceneDanceInformation.contentment)
            {
                baseEmotion = MoodEnums.MoodTypes.excited;
            }
            else
            {
                baseEmotion = MoodEnums.MoodTypes.content;
            }
        } else if (ds_Service.GameManagerInGame.sceneDanceInformation.excitement <
                   ds_Service.GameManagerInGame.sceneDanceInformation.affection)
        {
            if (ds_Service.GameManagerInGame.sceneDanceInformation.affection >
                ds_Service.GameManagerInGame.sceneDanceInformation.contentment)
            {
                baseEmotion = MoodEnums.MoodTypes.affectionate;
            }
            else
            {
                baseEmotion = MoodEnums.MoodTypes.content;
            }
        }
        else if (ds_Service.GameManagerInGame.sceneDanceInformation.excitement ==
                 ds_Service.GameManagerInGame.sceneDanceInformation.affection)
        {
            if (ds_Service.GameManagerInGame.sceneDanceInformation.affection >
                ds_Service.GameManagerInGame.sceneDanceInformation.contentment)
            {
                baseEmotion = tiebreaker;
            }
            else if (ds_Service.GameManagerInGame.sceneDanceInformation.affection <
                     ds_Service.GameManagerInGame.sceneDanceInformation.contentment)
            {
                baseEmotion = MoodEnums.MoodTypes.content; 
            }
            else
            {
                baseEmotion = tiebreaker;
            }
        }
    }

    public void UpdateBehaviorEmotion()
    {
        behaviorEmotion = baseEmotion;
    }
}
