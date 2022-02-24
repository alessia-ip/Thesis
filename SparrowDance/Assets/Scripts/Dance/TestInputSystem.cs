using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInputSystem : MonoBehaviour
{
    public PlayerInput InputActions;
    
    // Start is called before the first frame update
    void Start()
    {
        InputActions.actions["Spontaneous"].performed += SpontaneousInput;
        InputActions.actions["Calm"].performed += CalmInput;
        InputActions.actions["Passionate"].performed += PassionateInput;
        InputActions.actions["Encouraging"].performed += EncouragingInput;
    }

    private void SpontaneousInput(InputAction.CallbackContext obj)
    {
        Debug.Log("spontaneous");
    }
    
    private void CalmInput(InputAction.CallbackContext obj)
    {
        Debug.Log("calm");
    }
    private void PassionateInput(InputAction.CallbackContext obj)
    {
        Debug.Log("passionate");
    }
    private void EncouragingInput(InputAction.CallbackContext obj)
    {
        Debug.Log("encouraging");
    }

    
}
