using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial_CompleteTutorialSteps : MonoBehaviour
{
    
    public PlayerInput InputActions;

    public Tutorial_CurrentState CurrentState;
    public Tutorial_StepsCompleted StepsCompleted;
    public Tutorial_TestDanceMoves danceMoves;
    public Tutorial_TestTiming TestTiming;

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
        InputActions.currentActionMap.actions[5].performed += AdvanceToDance;
    }

    private void AdvanceToDance(InputAction.CallbackContext obj)
    {
        if (CurrentState.StateNumber == 4)
        {
            if (StepsCompleted.revealedEmotions &&
                StepsCompleted.triedACombo &&
                StepsCompleted.dancedInTime)
            {
                SceneManager.LoadScene(2);
            }
        }
    }


    private void SpontaneousInput(InputAction.CallbackContext obj) //val 0
    {
        Debug.Log("Spontaneous");
        if (CurrentState.StateNumber == 2)
        {
            EmotionFour = true;
            EmotionFourO.SetActive(false);
        }
        
        if (CurrentState.StateNumber == 3)
        {
            if (!danceMoves.BInputOne)
            {
                danceMoves.BInputOne = true;
                danceMoves.ImgInputOne.GetComponent<Image>().sprite = danceMoves.Spontaneous;
                danceMoves.NumInputOne = 0;
            }
            else if (!danceMoves.BInputTwo)
            {
                danceMoves.BInputTwo = true;
                danceMoves.ImgInputTwo.GetComponent<Image>().sprite = danceMoves.Spontaneous;
                danceMoves.NumInputTwo = 0;
            }
        }

        if (CurrentState.StateNumber == 4)
        {
            TestTiming.InputNewValue(0);
        }
        
    }
    
    private void CalmInput(InputAction.CallbackContext obj) //val 1
    {
        Debug.Log("Calm");
        if (CurrentState.StateNumber == 2)
        {
            EmotionTwo = true;
            EmotionTwoO.SetActive(false);
        }
        
        if (CurrentState.StateNumber == 3)
        {
            if (!danceMoves.BInputOne)
            {
                danceMoves.BInputOne = true;
                danceMoves.ImgInputOne.GetComponent<Image>().sprite = danceMoves.Calm;
                danceMoves.NumInputOne = 1;
            }
            else if (!danceMoves.BInputTwo)
            {
                danceMoves.BInputTwo = true;
                danceMoves.ImgInputTwo.GetComponent<Image>().sprite = danceMoves.Calm;
                danceMoves.NumInputTwo = 1;
            }
        }
        
        if (CurrentState.StateNumber == 4)
        {
            TestTiming.InputNewValue(1);
        }
    }
    
    private void PassionateInput(InputAction.CallbackContext obj) //val 2
    {
        Debug.Log("Passionate");
        if (CurrentState.StateNumber == 2)
        {
            EmotionThree = true;
            EmotionThreeO.SetActive(false);
        }
        
        if (CurrentState.StateNumber == 3)
        {
            if (!danceMoves.BInputOne)
            {
                danceMoves.BInputOne = true;
                danceMoves.ImgInputOne.GetComponent<Image>().sprite = danceMoves.Passionate;
                danceMoves.NumInputOne = 2;
            }
            else if (!danceMoves.BInputTwo)
            {
                danceMoves.BInputTwo = true;
                danceMoves.ImgInputTwo.GetComponent<Image>().sprite = danceMoves.Passionate;
                danceMoves.NumInputTwo = 2;
            }
        }
     
        if (CurrentState.StateNumber == 4)
        {
            TestTiming.InputNewValue(2);
        }
    }
    
    private void EncouragingInput(InputAction.CallbackContext obj) //val 3
    {
        Debug.Log("Encouraging");
        if (CurrentState.StateNumber == 2)
        {
            EmotionOne = true;
            EmotionOneO.SetActive(false);
        }

        if (CurrentState.StateNumber == 3)
        {
            if (!danceMoves.BInputOne)
            {
                danceMoves.BInputOne = true;
                danceMoves.ImgInputOne.GetComponent<Image>().sprite = danceMoves.Encouraging;
                danceMoves.NumInputOne = 3;
            }
            else if (!danceMoves.BInputTwo)
            {
                danceMoves.BInputTwo = true;
                danceMoves.ImgInputTwo.GetComponent<Image>().sprite = danceMoves.Encouraging;
                danceMoves.NumInputTwo = 3;
            }
        }
        
        if (CurrentState.StateNumber == 4)
        {
            TestTiming.InputNewValue(3);
        }
        
    }

    void Update()
    {
        if (EmotionOne && EmotionTwo && EmotionThree && EmotionFour)
        {
            StepsCompleted.revealedEmotions = true;
        }

        if (danceMoves.BInputOne && danceMoves.BInputTwo)
        {
            StepsCompleted.triedACombo = true;
        }

        if (TestTiming.playerButtonInputs[0] != 10 &&
            TestTiming.playerButtonInputs[1] != 10)
        {
            StepsCompleted.dancedInTime = true;
        }
    }
    
}
