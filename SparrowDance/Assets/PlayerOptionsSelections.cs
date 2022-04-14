using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerOptionsSelections : MonoBehaviour
{
    [HideInInspector]
    public bool thinking = false;

    [HideInInspector] public bool ableToSelectOptions = false;

    public GameObject optionBubbles;
    public GameObject thoughtBubble;
    
    public PlayerInput InputActions;

    public Overworld_PlayerController movementController;

    public Animator playerAnims;
    public Animator npcAnims;

    // Start is called before the first frame update
    void Start()
    {
        InputActions.actions["Dance"].performed += SelectDance;
        InputActions.actions["Think"].performed += SelectThink;
    }

    void GreetNpc()
    {
        if (thinking) return;
        if (!ableToSelectOptions) return;
    }
    
    void SelectThink(InputAction.CallbackContext obj)
    {
        if (!ableToSelectOptions) return;
        if (!thinking)
        {
            OpenThink();
        }
        else
        {
            CloseThink();
        }
    }

    void OpenThink()
    {
        thoughtBubble.SetActive(true);
        optionBubbles.SetActive(false);
        movementController.enabled = false;
        thinking = true;
    }
    
    void CloseThink()
    {
        thoughtBubble.SetActive(false);
        optionBubbles.SetActive(true);
        movementController.enabled = true;
        thinking = false;
    }
    
    void SelectDance(InputAction.CallbackContext obj)
    {
        if (thinking) return;
        if (!ableToSelectOptions) return;
        movementController.enabled = false;
        Invoke(nameof(playerBow), 0.01f);
    }

    void playerBow()
    {
        Invoke(nameof(npcBow), 1f);
    }

    void npcBow()
    {
        Invoke(nameof(LoadScene), 1f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
    
}
