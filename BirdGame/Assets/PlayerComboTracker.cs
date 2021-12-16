using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerComboTracker : MonoBehaviour
{
    public string[] buttons = new string[3];

    private const string twirl = "QQQ";
    private const string reach = "QEQ";
    private const string flex = "QWE";
    private const string wave = "WWW";
    private const string flourish = "WEQ";

    public string playerAction = "";

    public MoveAroundCircle _npc;
    
    private void Update()
    {
        if (buttons[0] != ""
            && buttons[1] != ""
            && buttons[2] != "")
        {
            var newString = buttons[0] + buttons[1] + buttons[2];
            switch (newString)
            {
                case twirl:
                    playerAction = "twirl";
                    break;
                case reach:
                    playerAction = "reach";
                    break;
                case flex:
                    playerAction = "flex";
                    break;
                case wave:
                    playerAction = "wave";
                    break;
                case flourish:
                    playerAction = "flourish";
                    break;
                default:
                    playerAction = "freestyle";
                    break;
            }
        }
        else
        {
            playerAction = "";
        }
    }


    public void AddStep()
    {
        var newString = buttons[0] + buttons[1] + buttons[2];
        var addStr = "";
        switch (newString)
        {
            case twirl:
                _npc.npcActionsList.Add("hold");
                break;
            case reach:
                _npc.npcActionsList.Add("down");
                break;
            case flex:
                _npc.npcActionsList.Add("up");
                break;
            case wave:
                _npc.npcActionsList.Add("down");
                break;
            case flourish:
                _npc.npcActionsList.Add("up");
                break;
            default:
                _npc.npcActionsList.Add("hold");
                break;
        }
    }
}
