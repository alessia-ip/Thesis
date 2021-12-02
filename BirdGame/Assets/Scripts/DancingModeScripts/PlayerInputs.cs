using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{

    public InputActionAsset danceActions;
    
    private void Awake()
    {
        
        danceActions.Enable();
        
        
        danceActions["Down Input"].performed += Down_action_performed;
        danceActions["Up Input"].performed += Up_action_performed;
        danceActions["Left Input"].performed += Left_action_performed;
        danceActions["Right Input"].performed += Right_action_performed;

    }

    private void Down_action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Down");
    }
    
    private void Left_action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Left");
    }
    
    private void Right_action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Right");
    }
    
    private void Up_action_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Up");
    }

}
