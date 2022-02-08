using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_npcActionManager : MonoBehaviour
{

    public List<string> Direction = new List<string>();
    public List<Action> NpcActions = new List<Action>();


    private void Start()
    {
        ds_Service.NpcActionsInLevel = this;
    }
}
