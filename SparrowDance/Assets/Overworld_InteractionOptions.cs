using UnityEngine;

public class Overworld_InteractionOptions : MonoBehaviour
{
    public GetLook _looking;
    public Overworld_DetectCharacter _detect;

    public GameObject optionsMenu;

    public PlayerOptionsSelections abilityToPickOptions;
    
    // Update is called once per frame
    void Update()
    {
        if (_detect.characterTrigger != null
            && _looking.LookingAtNPC)
        {
            optionsMenu.SetActive(true);
            abilityToPickOptions.ableToSelectOptions = true;
        }
        else
        {
            optionsMenu.SetActive(false);
            abilityToPickOptions.ableToSelectOptions = false;
        }
    }
}
