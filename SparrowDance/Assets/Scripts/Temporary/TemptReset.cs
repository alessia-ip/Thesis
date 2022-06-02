using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TemptReset : MonoBehaviour
{

    public DanceInfo danceInfoReset;
    public PlayerInput playerInputs;

    void Start()
    {
        playerInputs.actions["Reset"].performed += ResetGame;
        playerInputs.actions["Reset1"].performed += ResetGame;
        playerInputs.actions["Reset2"].performed += ResetGame;
    }
    
    // Update is called once per frame
    void ResetGame(InputAction.CallbackContext obj)
    {
        Debug.Log("Reset");
        danceInfoReset.vibe = 0;
        danceInfoReset.affection = 10;
        danceInfoReset.contentment = 5;
        danceInfoReset.excitement = 15;
        SceneManager.LoadScene(0);
        
    }
}
