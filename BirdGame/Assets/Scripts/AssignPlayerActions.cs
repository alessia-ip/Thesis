using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPlayerActions : MonoBehaviour
{

    public MoveAroundCircle _moveAroundPlayer;

    public GameObject[] actions;
    
    // Update is called once per frame
   public void ConfirmActions()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) && AudioListener.pause)
        {*/
           _moveAroundPlayer.playerActionsList.Clear();
           string playerAction;
           for (int i = 0; i < 8; i++)
           {
               switch (actions[i].GetComponent<PlayerUIButtons>().sprNum)
               {
                   case 0:
                       playerAction = "hold";
                       break;
                   case 1:
                       playerAction = "down";
                       break;
                   case 2:
                       playerAction = "up";
                       break;
                   default:
                       playerAction = "hold";
                       break;
               }
               _moveAroundPlayer.playerActionsList.Add(playerAction);
           }
        /*}*/
    }
    
}
