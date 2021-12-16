using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrintPlayerActionText : MonoBehaviour
{
    public PlayerComboTracker playerComboTracker ;
    
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TMP_Text>().text = playerComboTracker.playerAction;
        
       
    }
}
