using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : MonoBehaviour
{
    public PlayerInput InputActions;

    public GameObject sectionOne;
    public GameObject danceIndicator;
    public GameObject sectionTwo;
    public GameObject sectionThree;

    public bool seenOne = false;
    public bool seenTwo = false;
    public bool seenThree = false;
        
    private void Start()
    {
        danceIndicator.SetActive(false);
        ds_Service.GameManagerInGame.isInMenu = true;
        InputActions.actions["Encouraging"].performed += closeSectionOne;
        InputActions.actions["Spontaneous"].performed += closeSectionTwo;
        InputActions.actions["Spontaneous"].performed += closeSectionThree;
    }

    // Update is called once per frame
    void closeSectionOne(InputAction.CallbackContext obj)
    {
        if (seenOne) return;
        
        sectionOne.SetActive(false);
        danceIndicator.SetActive(true);
        sectionTwo.SetActive(true);

        seenOne = true;
        
    }

    void closeSectionTwo(InputAction.CallbackContext obj)
    {
        if (!seenOne) return;
        if (seenTwo) return;

        sectionTwo.SetActive(false);
        sectionThree.SetActive(true);
        seenTwo = true;

        Invoke(nameof(closeMenuInvoke), 0.5f);
        
    }

    void closeMenuInvoke()
    {
        ds_Service.GameManagerInGame.isInMenu = false;
    }

    void closeSectionThree(InputAction.CallbackContext obj)
    {
        if (!seenTwo) return;
        if (seenThree) return;
        if (ds_Service.GameManagerInGame.isInMenu) return;
        

        seenThree = true;
        
        sectionThree.SetActive(false);
        
    }
}
