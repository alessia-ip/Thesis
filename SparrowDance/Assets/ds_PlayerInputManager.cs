using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ds_PlayerInputManager : MonoBehaviour
{
    public PlayerInput InputActions;
    
    // Start is called before the first frame update
    void Start()
    {
        //dance phase inputs
        InputActions.actions["Spontaneous"].performed += SpontaneousInput;
        InputActions.actions["Calm"].performed += CalmInput;
        InputActions.actions["Passionate"].performed += PassionateInput;
        InputActions.actions["Encouraging"].performed += EncouragingInput;
        
        
        //planning phase inputs not handled by UI
        InputActions.actions["Spontaneous"].performed += StartDancePhase;
    }


    #region DancePhaseInputs
    
    private void SpontaneousInput(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.dancing) return;
        
        
    }
    
    private void CalmInput(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.dancing) return;
        
    }
    private void PassionateInput(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.dancing) return;
    }
    private void EncouragingInput(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.dancing) return;
    }
    
    
    #endregion

    #region PlanningPhaseInputs

    private void StartDancePhase(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.planning) return;
        ds_Service.EventManagerInGame._StartCountdownSection();
    }

    #endregion
    
}
