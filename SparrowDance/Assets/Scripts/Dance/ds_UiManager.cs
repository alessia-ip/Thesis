using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ds_UiManager : MonoBehaviour
{
    public Slider playerSlider;
    public Slider npcSlider;

    public GameObject playerPlanningCanv;
    public GameObject npcPlanningCanv;

    public Text NpcEmotionText;

    public GameObject sliderObject;
    
    void Start()
    {
        ds_Service.EventManagerInGame._TriggerBeat += turnOffSliderCanv;
        ds_Service.EventManagerInGame._TriggerBeat += turnOnSliderCanv;
        ds_Service.EventManagerInGame._StartPlanningSection += turnOnSliderCanvV2;
    }

    void turnOffSliderCanv()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 4) return;
        sliderObject.SetActive(false);
    }
    void turnOnSliderCanv()
    {
        if (ds_Service.TimingManagerInGame.fourByFourBeatNumber != 1) return;
        sliderObject.SetActive(true);
    }
    
    void turnOnSliderCanvV2()
    {
        sliderObject.SetActive(true);
    }
    
    void Update()
    {
       updateSliderPosition();
       if (ds_Service.GameManagerInGame.currentGameState == ds_GameManager.GameState.planning)
       {
           turnPlanningCanvasesOn();
           UpdateNpcEmotion();
       }
       else
       {
           turnPlanningCanvasesOff();
       }
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

    public void turnPlanningCanvasesOff()
    {
        npcPlanningCanv.SetActive(false);
        playerPlanningCanv.SetActive(false);
    }

    public void turnPlanningCanvasesOn()
    {
        npcPlanningCanv.SetActive(true);
        playerPlanningCanv.SetActive(true);
    }

    public void UpdateNpcEmotion()
    {
        switch (ds_Service.EmotionTrackerInGame.baseEmotion)
        {
            case MoodEnums.MoodTypes.affectionate:
                NpcEmotionText.text = "Affectionate";
                break;
            case MoodEnums.MoodTypes.content:
                NpcEmotionText.text = "Content";
                break;
            case MoodEnums.MoodTypes.excited:
                NpcEmotionText.text = "Excited";
                break;
        }
    }
    
}
