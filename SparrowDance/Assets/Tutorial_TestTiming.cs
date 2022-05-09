using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Tutorial_TestTiming : MonoBehaviour
{
    public int[] playerButtonInputs = new int[2];

    private bool CanInputOne = false;
    private bool CanInputTwo = false;
    
    
    [Header("NPC Indicators To Change to")]
    public GameObject npcIndicatorC;
    public GameObject npcIndicatorS;
    public GameObject npcIndicatorP;
    public GameObject npcIndicatorE;
    
    [Header("Player Indicators To Change to")]
    public GameObject pIndicatorC;
    public GameObject pIndicatorS;
    public GameObject pIndicatorP;
    public GameObject pIndicatorE;
    
    [Header("Player Indicators To Change to 2")]
    public GameObject pIndicatorC2;
    public GameObject pIndicatorS2;
    public GameObject pIndicatorP2;
    public GameObject pIndicatorE2;

    public Tutorial_TimingManager TimingManager;
    
    private void Start()
    {
        TimingManager.beatTutorial += ResetIndicators;
        TimingManager.beatTutorial += updateNPCIndicator;
        TimingManager.beatTutorial += AllowInputOne;
        TimingManager.beatTutorial += AllowInputTwo;
        TimingManager.beatTutorial += ClearValues;
        ClearIndicators();
        ClearValues();
    }

    public void ClearIndicators()
    {

        npcIndicatorC.SetActive(false);
        npcIndicatorS.SetActive(false);
        npcIndicatorP.SetActive(false);
        npcIndicatorE.SetActive(false);

        pIndicatorC.SetActive(false);
        pIndicatorS.SetActive(false);
        pIndicatorP.SetActive(false);
        pIndicatorE.SetActive(false);

        pIndicatorC2.SetActive(false);
        pIndicatorS2.SetActive(false);
        pIndicatorP2.SetActive(false);
        pIndicatorE2.SetActive(false);
    }
    
    public void ResetIndicators()
    {
        if (TimingManager.fourByFourBeatNumber != 4) return;
        
        npcIndicatorC.SetActive(false);
        npcIndicatorS.SetActive(false);
        npcIndicatorP.SetActive(false);
        npcIndicatorE.SetActive(false);

        pIndicatorC.SetActive(false);
        pIndicatorS.SetActive(false);
        pIndicatorP.SetActive(false);
        pIndicatorE.SetActive(false);

        pIndicatorC2.SetActive(false);
        pIndicatorS2.SetActive(false);
        pIndicatorP2.SetActive(false);
        pIndicatorE2.SetActive(false);
    }
    
    
    public void updateNPCIndicator()
    {
        if (TimingManager.fourByFourBeatNumber  != 1) return;

        var randomEmote = Random.Range(0, 2);
        
        switch (randomEmote)
        {
            case 0:
                npcIndicatorC.SetActive(true);
                break;
            case 1:
                npcIndicatorS.SetActive(true);
                break;
            case 2:
                npcIndicatorP.SetActive(true);
                break;
        }
    }

    public void updatePlayerIndicator(int whichIndicator, int value)
    {
        if (whichIndicator == 1)
        {
            switch (value)
            {
                case 0:
                    pIndicatorS.SetActive(true);
                    break;
                case 1:
                    pIndicatorC.SetActive(true);
                    break;
                case 2:
                    pIndicatorP.SetActive(true);
                    break;
                case 3:
                    pIndicatorE.SetActive(true);
                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (value)
            {
                case 0:
                    pIndicatorS2.SetActive(true);
                    break;
                case 1:
                    pIndicatorC2.SetActive(true);
                    break;
                case 2:
                    pIndicatorP2.SetActive(true);
                    break;
                case 3:
                    pIndicatorE2.SetActive(true);
                    break;
            }
        }
    }
    
    public void ClearValues()
    {

        if (TimingManager.fourByFourBeatNumber != 1) return;
        
        //we can't use 0 because 0 is an array value I need
        playerButtonInputs[0] = 10;
        playerButtonInputs[1] = 10;
       
    }
    
    void AllowInputOne()
    {
        if (TimingManager.fourByFourBeatNumber != 1) return;
        Invoke(nameof(StartInputOne), TimingManager.secondsPerBeat/2);
    }
    
    
    void StartInputOne()
    {
        CanInputOne = true;
        Invoke(nameof(StopInputOne), TimingManager.secondsPerBeat);
    }

    void StopInputOne()
    {
        CanInputOne = false;
    }
    
   
    
    void AllowInputTwo()
    {
        if (TimingManager.fourByFourBeatNumber != 2) return;
        Invoke(nameof(StartInputTwo), TimingManager.secondsPerBeat/2);
    }
    
    void StartInputTwo()
    {
        CanInputTwo = true;
        Invoke(nameof(StopInputTwo), TimingManager.secondsPerBeat);
    }

    void StopInputTwo()
    {
        CanInputTwo = false;
    }
    
    
    public void InputNewValue(int InputVal)
    {
        if (TimingManager.fourByFourBeatNumber == 4) return;
        
        if (CanInputOne)
        {
            if (playerButtonInputs[0] == 10)
            {
                playerButtonInputs[0] = InputVal;
                updatePlayerIndicator(1, playerButtonInputs[0]);
            }
        } else if (CanInputTwo && !CanInputOne)
        {
            if (playerButtonInputs[1] == 10)
            {
                playerButtonInputs[1] = InputVal;
                updatePlayerIndicator(2, playerButtonInputs[1]);
            }
        }
        
    }
    
    
    
    
}
