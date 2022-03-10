using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//[CanEditMultipleObjects]
[CreateAssetMenu(fileName = "DanceActions", menuName = "ScriptableObjects/Dance Actions")]
public class DanceActions : ScriptableObject
{
    public enum emotion
    {
        Spontaneous,
        Calm,
        Passionate,
        Encouraging
    }

    [Serializable]
    public class playerInput
    {
        public string inputName;
        public emotion inputMainEmotion;
    }
    
    public string characterName;
    
    public string actionName;
    public emotion mainEmotion;
    public PlayersDanceActions PreferredAction;
    public UnityEvent PreferredEventsToCall;
    public PlayersDanceActions[] AcceptedActions;
    public UnityEvent AcceptedEventsToCall;
    public UnityEvent OtherEventsToCall;
    
    public void PreferredReactionEvents()
    {
        PreferredEventsToCall.Invoke();
    }
    
    public void OtherAcceptedReactionEvents()
    {
        AcceptedEventsToCall.Invoke();
    }

    public void OtherReactionEvents()
    {
        OtherEventsToCall.Invoke();
    }

}