using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSystem : MonoBehaviour
{
    public enum systemType
    {
        Mac,
        Windows
    }

    public systemType _systemType; 
    
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || 
            Application.platform == RuntimePlatform.WindowsPlayer) 
        {
            Debug.Log("Windows");
            _systemType = systemType.Windows;
        } else if (Application.platform == RuntimePlatform.OSXEditor ||
                   Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("Mac");
            _systemType = systemType.Mac;
        }
    }
}
