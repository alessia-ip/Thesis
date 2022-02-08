using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_AllowableActions : MonoBehaviour
{
    public List<Action> possibleActions = new List<Action>();

    private void Start()
    {
        ds_Service.AllowableActionsInLevel = this;
    }
}
