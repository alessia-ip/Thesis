using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_LightsOnBeat : MonoBehaviour
{

    [SerializeField]
    private Tutorial_TimingManager _timingManager;

    [SerializeField] private int beatToTriggerOn;

    private Image litLights;

    private bool animate = false;

    private float StartTime;
    float duration;
    
    // Start is called before the first frame update
    void Start()
    {
        _timingManager.beatTutorial += TriggerBeatAnim;
        _timingManager.beatTutorial += ResetAnim;

        litLights = this.gameObject.GetComponent<Image>();
        litLights.fillAmount = 0;

        duration = 0.7f;
    }

    void Update()
    {
        if (animate)
        {
            float t = (Time.time - StartTime) / duration;
            var newFill = Mathf.SmoothStep(0f, 1f, t);
            litLights.fillAmount = newFill;
        }
    }
    
    void TriggerBeatAnim()
    {
        if (_timingManager.fourByFourBeatNumber != beatToTriggerOn) return;

        StartTime = Time.time;
        
        animate = true;

    }

    void ResetAnim()
    {
        if (_timingManager.fourByFourBeatNumber != 4) return;

        animate = false;
        litLights.fillAmount = 0;
    }
    
}
