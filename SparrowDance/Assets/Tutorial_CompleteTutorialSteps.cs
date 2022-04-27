using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial_CompleteTutorialSteps : MonoBehaviour
{
    
    public PlayerInput InputActions;

    public Tutorial_CurrentState CurrentState;
    public Tutorial_StepsCompleted StepsCompleted;

    private bool EmotionOne = false;
    private bool EmotionTwo = false;
    private bool EmotionThree = false;
    private bool EmotionFour = false;
    
    public GameObject EmotionOneO;
    public GameObject EmotionTwoO;
    public GameObject EmotionThreeO;
    public GameObject EmotionFourO;
    
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
        if (CurrentState.StateNumber == 2)
        {
            EmotionFour = true;
            EmotionFourO.SetActive(false);
        }
        
    }
    
    private void CalmInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Calm");
        if (CurrentState.StateNumber == 2)
        {
            EmotionTwo = true;
            EmotionTwoO.SetActive(false);
        }
        
    }
    
    private void PassionateInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Passionate");
        if (CurrentState.StateNumber == 2)
        {
            EmotionThree = true;
            EmotionThreeO.SetActive(false);
        }
        
    }
    
    private void EncouragingInput(InputAction.CallbackContext obj)
    {
        Debug.Log("Encouraging");
        if (CurrentState.StateNumber == 2)
        {
            EmotionOne = true;
            EmotionOneO.SetActive(false);
        }
        
    }

    void Update()
    {
        if (EmotionOne && EmotionTwo && EmotionThree && EmotionFour)
        {
            StepsCompleted.revealedEmotions = true;
        }
    }
    
}
