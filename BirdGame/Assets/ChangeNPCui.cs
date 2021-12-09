using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNPCui : MonoBehaviour
{

    public GameObject slotHolder;
    public GameObject playerSlotHolder;

    public GameObject[] slots = new GameObject[5];

    public Sprite sprOut;
    public Sprite sprIn;
    public Sprite sprHold;

    public CircleBPM _circleBpm;
    public MoveAroundCircle _moveAround;

    // Update is called once per frame
    void Update()
    {

        if (AudioListener.pause)
        {
            slotHolder.SetActive(true);
            playerSlotHolder.SetActive(true);
        }
        else
        {
            slotHolder.SetActive(false);
            playerSlotHolder.SetActive(false);
        }
        
        for (int i = 0; i < 8; i++)
        {
            var currentSlot = slots[i];
            var currentBeatInt = i;
            switch (_moveAround.npcActionsList[currentBeatInt].ToLower().Replace(" ",""))
            {
                case "up":
                    currentSlot.GetComponent<SpriteRenderer>().sprite = sprOut;
                    break;
                case "down":
                    currentSlot.GetComponent<SpriteRenderer>().sprite = sprIn;
                    break;
                case "hold":
                    currentSlot.GetComponent<SpriteRenderer>().sprite = sprHold;
                    break;
            }
        }
    }
}
