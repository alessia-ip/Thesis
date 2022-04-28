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
        InputActions.currentActionMap.actions[0].performed += SpontaneousInput;
        InputActions.currentActionMap.actions[1].performed += CalmInput;
        InputActions.currentActionMap.actions[2].performed += PassionateInput;
        InputActions.currentActionMap.actions[3].performed += EncouragingInput;
        
        
        //planning phase inputs not handled by UI
        InputActions.currentActionMap.actions[4].performed += ReverseStart;
        InputActions.currentActionMap.actions[5].performed += MirrorStart;
        
        
    }


    #region DancePhaseInputs
    
    private void SpontaneousInput(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.dancing) return;
        Debug.Log("I'M DOING THE THING");
        ds_Service.InputRecords.InputNewValue(0);
    }
    
    private void CalmInput(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.dancing) return;
        
        ds_Service.InputRecords.InputNewValue(1);
    }
    private void PassionateInput(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.dancing) return;
        
        ds_Service.InputRecords.InputNewValue(2);
    }
    private void EncouragingInput(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.dancing) return;
        
        ds_Service.InputRecords.InputNewValue(3);
    }
    
    
    #endregion

    #region PlanningPhaseInputs

    private void ReverseStart(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.planning) return;
        if (ds_Service.GameManagerInGame.isInMenu) return;

        Debug.Log("reverse");
        
        ds_Service.DirectionDetermination.isWith = false;
        
        ds_Service.EventManagerInGame._StartCountdownSection();
    }
    
    private void MirrorStart(InputAction.CallbackContext obj)
    {
        if (ds_Service.GameManagerInGame.currentGameState != ds_GameManager.GameState.planning) return;
        if (ds_Service.GameManagerInGame.isInMenu) return;
        
        Debug.Log("Mirror");
        
        ds_Service.DirectionDetermination.isWith = true;
        
        ds_Service.EventManagerInGame._StartCountdownSection();
    }

    #endregion
    
}
