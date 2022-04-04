using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTurnOffMenu : MonoBehaviour
{
    public GameObject turnMeOff;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            turnMeOff.SetActive(false);
        }
    }
}
