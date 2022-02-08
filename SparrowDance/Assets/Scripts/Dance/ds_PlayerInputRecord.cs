using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_PlayerInputRecord : MonoBehaviour
{
    [System.Serializable] 
    public class PlayerInputAction {
        //Variable declaration
        //I'm explicitly declaring them as public, but they are public by default.
        public bool isRecorded = false;
        public ds_ActionInputTimer.TimingScore timingScore; //whether or not the action was good
        public string InputValue; //what the specific keypress is

        //Constructor (not necessary, but helpful)
        public PlayerInputAction(ds_ActionInputTimer.TimingScore timingScore, string InputValue) {
            this.timingScore = timingScore;
            this.InputValue = InputValue;
        }
    }
    
    public PlayerInputAction[] PlayerDanceInputs = new PlayerInputAction[3];
}
