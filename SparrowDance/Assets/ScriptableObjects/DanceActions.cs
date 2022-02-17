using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[CanEditMultipleObjects]
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
    
    public string characterName;
    
    public string actionName;
    public emotion mainEmotion;
    public UnityEvent callbackEvt;

    public void PreferredReactionEvents()
    {
        callbackEvt.Invoke();
    }
    
    public void OtherAcceptedReactionEvents()
    {
        callbackEvt.Invoke();
    }

    public void OtherReactionEvents()
    {
        callbackEvt.Invoke();
    }
    
}