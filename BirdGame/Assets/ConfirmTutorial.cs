using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmTutorial : MonoBehaviour
{
   public GameObject realButton;
   public GameObject tutCanvTwo;
   
   public void confirmTutorialDance()
   {
      tutCanvTwo.SetActive(true);
      realButton.SetActive(true);
      this.gameObject.SetActive(false);
   }
}
