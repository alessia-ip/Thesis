using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource danceAudio;
    public AudioSource planningAudio;

    public BPMManager _bpmManager;
    
    void Start()
    {
        planningAudio.Play();
    }

    public void StartDancePhaseAudio()
    {
        planningAudio.Pause();
        _bpmManager.TrackOveralTime();
        danceAudio.Play();
    }
        
    public void StartPlanningPhaseAudio()
    {
        danceAudio.Pause();
        planningAudio.Play();
        Debug.Log(danceAudio.time);
    }
    
}
