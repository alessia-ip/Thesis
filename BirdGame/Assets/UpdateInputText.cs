using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateInputText : MonoBehaviour
{
    public PlayerComboTracker comboTracker;
    public int index;
    
    // Update is called once per frame
    void Update()
    {
        GetComponent<TMP_Text>().text = comboTracker.buttons[index];
    }
}
