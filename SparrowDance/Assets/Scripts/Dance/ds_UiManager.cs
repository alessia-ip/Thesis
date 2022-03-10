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
