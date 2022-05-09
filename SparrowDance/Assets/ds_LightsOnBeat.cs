using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ds_LightsOnBeat : MonoBehaviour
{

    [SerializeField] private int beatToTriggerOn;

    private Image litLights;

    private bool animate = false;

    private float StartTime;
    float duration;
    
    // Start is called before the first frame update
    void Start()
    {
        ds_Service.EventManagerInGame._TriggerBeat += TriggerBeatAnim;
        ds_Service.EventManagerInGame._TriggerBeat += ResetAnim;

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
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != beatToTriggerOn) return;

        StartTime = Time.time;
        
        animate = true;

    }

    void ResetAnim()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 4) return;

        animate = false;
        litLights.fillAmount = 0;
    }

}
