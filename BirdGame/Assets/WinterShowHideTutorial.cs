using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterShowHideTutorial : MonoBehaviour
{

    public void HideTutorialMenu()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
    }

}
