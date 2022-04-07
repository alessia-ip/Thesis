using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCThoughtBubbleColorPicker : MonoBehaviour
{

    public Color ExcitedColor;
    public Color ContentColor;
    public Color AffectionateColor;

    public GameObject NpcThoughtBubble;
    
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
                NpcThoughtBubble.GetComponent<Image>().color = AffectionateColor;
                break;
            case MoodEnums.MoodTypes.content:
                NpcThoughtBubble.GetComponent<Image>().color = ContentColor;
                break;
            case MoodEnums.MoodTypes.excited:
                NpcThoughtBubble.GetComponent<Image>().color = ExcitedColor;
                break;
            default:
                NpcThoughtBubble.GetComponent<Image>().color = Color.white;
                break;
        }
    }
}
