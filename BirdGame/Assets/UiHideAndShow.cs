using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHideAndShow : MonoBehaviour
{

    public GameObject danceUI;
    public GameObject actionUI;

    public GameObject HexGrid;
    
    public void DancePhaseUI()
    {
        actionUI.SetActive(false);
        danceUI.SetActive(true);
        HexGrid.SetActive(true);
        //TODO - RESET
    }

    public void ActionPhaseUI()
    {
        actionUI.SetActive(true);
        danceUI.SetActive(false);
        HexGrid.SetActive(false);
        //TODO - RESET
    }
}
