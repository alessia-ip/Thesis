using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrintActionTextNpc : MonoBehaviour
{
    public NPCActions npcActions;
    
    // Update is called once per frame
    void Update()
    {
        if (npcActions.currentAction != -1)
        {
            this.GetComponent<TMP_Text>().text = npcActions.actionSet[npcActions.currentAction];
        }
    }
}
