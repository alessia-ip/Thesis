using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ds_UiManager : MonoBehaviour
{
    public Slider playerSlider;
    public Slider npcSlider;
    
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

    public void updateChoiceIndicatorOn(GameObject image)
    {
        image.SetActive(true);
    }
    public void updateChoiceIndicatorOff(GameObject image)
    {
        image.SetActive(false);
    }
}
