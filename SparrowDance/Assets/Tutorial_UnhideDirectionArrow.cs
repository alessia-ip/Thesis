using UnityEngine;
using UnityEngine.UI;

public class Tutorial_UnhideDirectionArrow : MonoBehaviour
{
    
    
    [SerializeField] private Tutorial_StepsCompleted _stepsCompleted;
    [SerializeField] private bool firstUnhide = false;
    [SerializeField] private bool secondtUnhide = false;

    // Update is called once per frame
    void Update()
    {
        if (firstUnhide && _stepsCompleted.revealedEmotions)
        {
            this.GetComponent<Image>().enabled = true;
        } else if (secondtUnhide && _stepsCompleted.triedACombo)
        {
            this.GetComponent<Image>().enabled = true;
        }
    }
}
