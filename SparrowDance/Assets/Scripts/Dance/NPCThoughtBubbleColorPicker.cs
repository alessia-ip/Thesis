using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCThoughtBubbleColorPicker : MonoBehaviour
{

    /*public Color ExcitedColor;
    public Color ContentColor;
    public Color AffectionateColor;

    public GameObject NpcThoughtBubble;*/

    public GameObject thoughtIcon;

    public Sprite excitedS;
    public Sprite passionateS;
    public Sprite calmS;

    private ds_CurrentNpcEmotion emotion;
    
    // Start is called before the first frame update
    void Start()
    {
        emotion = ds_Service.EmotionTrackerInGame;
    }

    // Update is called once per frame
    void Update()
    {
        switch (emotion.behaviorEmotion)
        {
            case MoodEnums.MoodTypes.affectionate:
                thoughtIcon.GetComponent<Image>().sprite = passionateS;
                break;
            case MoodEnums.MoodTypes.content:
                thoughtIcon.GetComponent<Image>().sprite = calmS;
                break;
            case MoodEnums.MoodTypes.excited:
                thoughtIcon.GetComponent<Image>().sprite = excitedS;
                break;
            default:
                break;
        }
    }
}
