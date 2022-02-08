using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_EventManager : MonoBehaviour
{
    public delegate void StartDanceSection();
    public StartDanceSection _StartDanceSection;

    public delegate void TriggerBeat();
    public TriggerBeat _TriggerBeat;

    public delegate void VibeMatch();
    public VibeMatch VibeIsMatched;
    
    void Start()
    {
        ds_Service.EventManagerInGame = this;
    }
    
}
