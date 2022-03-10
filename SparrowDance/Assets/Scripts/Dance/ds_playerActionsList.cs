using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_playerActionsList : MonoBehaviour
{
    public PlayersDanceActions[,] allPlayerDanceActionCombos = new PlayersDanceActions[4, 4];

    [Tooltip("Wiggle")]
    public PlayersDanceActions zero_zero;
    [Tooltip("Foot Tap +S")]
    public PlayersDanceActions zero_one;
    [Tooltip("Twirl +S")]
    public PlayersDanceActions zero_two;
    [Tooltip("Point +S")]
    public PlayersDanceActions zero_three;
    
    [Tooltip("Foot Tap +C")]
    public PlayersDanceActions one_zero;
    [Tooltip("Wavey")]
    public PlayersDanceActions one_one;
    [Tooltip("Sway +C")]
    public PlayersDanceActions one_two;
    [Tooltip("Point +S")]
    public PlayersDanceActions one_three;
    
    [Tooltip("Twirl +P")]
    public PlayersDanceActions two_zero;
    [Tooltip("Stretch your leg +P")]
    public PlayersDanceActions two_one;
    [Tooltip("Blow a kiss")]
    public PlayersDanceActions two_two;
    [Tooltip("Pose +P")]
    public PlayersDanceActions two_three;
    
    [Tooltip("Point +E")]
    public PlayersDanceActions three_zero;
    [Tooltip("Sway +E")]
    public PlayersDanceActions three_one;
    [Tooltip("Pose +E")]
    public PlayersDanceActions three_two;
    [Tooltip("Beckon")]
    public PlayersDanceActions three_three;

    private void Start()
    {
        
        allPlayerDanceActionCombos[0,0] = zero_zero;
        allPlayerDanceActionCombos[0,1] = zero_one;
        allPlayerDanceActionCombos[0,2] = zero_two;
        allPlayerDanceActionCombos[0,3] = zero_three;
        
        allPlayerDanceActionCombos[1,0] = one_zero;
        allPlayerDanceActionCombos[1,1] = one_one;
        allPlayerDanceActionCombos[1,2] = one_two;
        allPlayerDanceActionCombos[1,3] = one_three;
        
        allPlayerDanceActionCombos[2,0] = two_zero;
        allPlayerDanceActionCombos[2,1] = two_one;
        allPlayerDanceActionCombos[2,2] = two_two;
        allPlayerDanceActionCombos[2,3] = two_three;
        
        allPlayerDanceActionCombos[3,0] = three_zero;
        allPlayerDanceActionCombos[3,1] = three_one;
        allPlayerDanceActionCombos[3,2] = three_two;
        allPlayerDanceActionCombos[3,3] = three_three;


        ds_Service.AllPlayerActionsInGame = this;
    }
    
    
    /*
    Wiggle  Spontaneous Spontaneous 0,0
    Foot Tap +S Spontaneous	Calm	0,1
    Twirl +S	Spontaneous	Passionate	0,2
    Point +S	Spontaneous	Encourage	0,3
    Wavey	Calm	Calm	1,1
    Stretch your leg +C	Calm	Passionate	1,2
    Sway +C	Calm	Encourage	1,3
    Foot Tap +C	Calm	Spontaneous	1,0
    Blow a kiss	Passionate	Passionate	2,2
    Pose +P	Passionate	Encourage	2,3
    Twirl +P	Passionate	Spontaneous	2,0
    Stretch your leg +P	Passionate	Calm	2,1
    Beckon	Encourage	Encourage	3,3
    Point +E	Encourage	Spontaneous	3,0
    Sway +E	Encourage	Calm	3,1
    Pose +E	Encourage	Passionate	3,2
    */
}
