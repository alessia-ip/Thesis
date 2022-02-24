using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Slider playerSlider;
    public Slider npcSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       updateSliderPosition(); 
    }

    public void updateSliderPosition()
    {
        var sliderValue = ds_Service.GameManagerInGame.sceneDanceInformation.vibe / 100;
        playerSlider.value = sliderValue;
        npcSlider.value = sliderValue;
    }
}
