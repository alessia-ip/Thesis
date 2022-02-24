using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ds_npcActionManager : MonoBehaviour
{
    public List<DanceActions> NpcContentActions = new List<DanceActions>();
    public List<DanceActions> NpcExcitedActions = new List<DanceActions>();
    public List<DanceActions> NpcAffectionateActions = new List<DanceActions>();
    public List<DanceActions> NpcEncouragingActions = new List<DanceActions>();

    public DanceActions currentlySelectedAction;

    [Tooltip("Number between 1 and 10 that determines what % of the time the NPC will pick the same type of action as their mood. " +
             "Anything else will be random OR/AND encouraging")]
    public int SplitOne_SameType; 
    [Tooltip("Number between the SameSplit and 10 that determines what % of the time the NPC will pick a different type of action from their mood. " +
             "Anything else will be encouraging")]
    public int SplitTwo_DifferentType;
    
    private void Start()
    {
        ds_Service.NpcActionsInLevel = this;
        Random.seed = (int)(System.DateTime.Now.Second * Time.deltaTime);
    }

    public void pickAction()
    {
        List<DanceActions> actionsToChooseFrom = new List<DanceActions>();
        
        var randomNum = (Random.Range(1, 10));
        if (randomNum <= SplitOne_SameType)
        {
            //pick the same kind of action as mood
            
            if (ds_Service.EmotionTrackerInGame.behaviorEmotion == MoodEnums.MoodTypes.affectionate)
            {
                actionsToChooseFrom = NpcAffectionateActions;
            } else if (ds_Service.EmotionTrackerInGame.behaviorEmotion == MoodEnums.MoodTypes.content)
            {
                actionsToChooseFrom = NpcContentActions;
            }
            else
            {
                actionsToChooseFrom = NpcExcitedActions;
            }

            var randomAction = Random.Range(1, actionsToChooseFrom.Count);
            currentlySelectedAction = actionsToChooseFrom[randomAction - 1];

        } else if (randomNum > SplitTwo_DifferentType)
        {
            //pick an encouraging action
            actionsToChooseFrom = NpcEncouragingActions;
            var randomAction = Random.Range(1, actionsToChooseFrom.Count);
            currentlySelectedAction = actionsToChooseFrom[randomAction - 1];
        }
        else
        {
            //pick a random, NOT same mood action
            
            if (ds_Service.EmotionTrackerInGame.behaviorEmotion == MoodEnums.MoodTypes.affectionate)
            {
                actionsToChooseFrom.AddRange(NpcContentActions);
                actionsToChooseFrom.AddRange(NpcExcitedActions);
            } else if (ds_Service.EmotionTrackerInGame.behaviorEmotion == MoodEnums.MoodTypes.content)
            {
                actionsToChooseFrom.AddRange(NpcExcitedActions);
                actionsToChooseFrom.AddRange(NpcAffectionateActions);
            }
            else
            {
                actionsToChooseFrom.AddRange(NpcAffectionateActions);
                actionsToChooseFrom.AddRange(NpcContentActions);
            }

            var randomAction = Random.Range(1, actionsToChooseFrom.Count);
            currentlySelectedAction = actionsToChooseFrom[randomAction - 1];
        }
    }
    
}
