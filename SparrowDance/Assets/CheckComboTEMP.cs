using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckComboTEMP : MonoBehaviour
{
    private bool buttonOne = false;
    private bool buttonTwo = false;

    public GameObject textTwo;
    public GameObject textThree;
    
    public Animator playerAnim;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            buttonOne = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            buttonTwo = true;
        }

        if (buttonOne && buttonTwo)
        {
            playerAnim.SetTrigger("Twirl");
            textThree.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
