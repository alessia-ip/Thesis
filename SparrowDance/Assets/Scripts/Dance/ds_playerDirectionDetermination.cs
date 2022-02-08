using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_playerDirectionDetermination : MonoBehaviour
{
    public bool isGoingLeft = false;

    public bool isWith;
    
    public void LeftOrRight()
    {
        isGoingLeft = !isGoingLeft;
        if (isGoingLeft)
        {
            if (ds_Service.NpcActionsInLevel.Direction[0] == "Left")
            {
                isWith = true;
            }
            else
            {
                isWith = false;
            }
        }
    }
}
