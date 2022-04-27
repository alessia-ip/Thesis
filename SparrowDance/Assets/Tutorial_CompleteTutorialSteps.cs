using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial_CompleteTutorialSteps : MonoBehaviour
{
    
    public PlayerInput InputActions;
    
    // Start is called before the first frame update
    void Start()
    {
        InputActions.currentActionMap.actions[1].performed += SpontaneousInput;
        InputActions.currentActionMap.actions[2].performed += CalmInput;
        InputActions.currentActionMap.actions[3].performed += PassionateInput;
        InputActions.currentActionMap.actions[4].performed += EncouragingInput;
    }

    private void SpontaneousInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Spontaneous");
    }
    
    private void CalmInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Calm");
    }
    
    private void PassionateInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Passionate");
    }
    
    private void EncouragingInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Encouraging");
    }
    
}
