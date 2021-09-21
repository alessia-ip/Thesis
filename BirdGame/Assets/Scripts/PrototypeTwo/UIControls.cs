using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{

    public MovesPlanned movesPlanned;
    public Button dance;
    public GameObject MoveSetOne;

    public Phase _turnPhase;
    
    public GameObject player;
    public GameObject playerGhost;
    
    // Update is called once per frame
    void Update()
    {
        if (movesPlanned.PlannedMoves.Count > 0)
        {
            dance.interactable = true;
        }
        else
        {
            dance.interactable = false;
        }
    }

    public void MoveOn()
    {
        foreach (Transform child in MoveSetOne.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void MoveOff()
    {
        foreach (Transform child in MoveSetOne.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void EndSelectPhase()
    {
        //_turnPhase._dancePhase = Phase.DancePhase.Beats;
        player.transform.position = playerGhost.transform.position;
        player.GetComponent<positionTracker>().GridPosition = playerGhost.GetComponent<positionTracker>().GridPosition;
        movesPlanned.PlannedMoves.Clear();
        movesPlanned.MoveCost.Clear();
    }


}
