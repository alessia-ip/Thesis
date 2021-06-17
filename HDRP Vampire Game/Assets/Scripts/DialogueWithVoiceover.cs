using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueWithVoiceover : MonoBehaviour
{
    
    public SO_Voiceover currentVoiceline;
    
    public AudioSource aud;
    public TextMeshProUGUI dialogueText;

   

    public int index = 0;
    public float previousTimestamp = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var tempArray = currentVoiceline.dialogue.Split(' ');
            var timeStamps = currentVoiceline.timestamps.Split(',');
            index = 0;
            previousTimestamp = 0;
            aud.PlayOneShot(currentVoiceline.voiceLine);
            Invoke("newVOCall", float.Parse(timeStamps[index]) - previousTimestamp);
        }
    }

    void playVO(string[] words, string[] stamps)
    {

        previousTimestamp = float.Parse(stamps[index]);
        if (index <= words.Length)
        {
            var STRING = "";
            for (int i = 0; i < words.Length; i++)
            {
                if (i == index)
                {
                    STRING = STRING + words[i] + " <alpha=#00>";
                }
                else
                {
                    STRING = STRING + words[i] + " ";
                }
            }
            dialogueText.text = STRING;
            index++;
           
            Invoke("newVOCall", float.Parse(stamps[index]) - previousTimestamp);
            
        }
    }

    void newVOCall()
    {
        var tempArray = currentVoiceline.dialogue.Split(' ');
        var timeStamps = currentVoiceline.timestamps.Split(',');
        playVO(tempArray, timeStamps);
    }
    
}
