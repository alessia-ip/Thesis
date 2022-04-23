using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTurnOffMenu : MonoBehaviour
{
    public GameObject turnMeOff;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            turnMeOff.SetActive(false);
        }

        if (ds_Service.GameManagerInGame.currentGameState == ds_GameManager.GameState.countdown ||
            ds_Service.GameManagerInGame.currentGameState == ds_GameManager.GameState.dancing)
        {
            turnMeOff.SetActive(false);
        }
    }
}
