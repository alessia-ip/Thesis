using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerInputs : MonoBehaviour
{
    //This is for saving real-time inputs

    public List<int> PlayerKeyInputs;
    //checking against ints is slightly more efficient than checking against a string, for the future

    public List<OnBeat.timing> playerTiming;

    
    
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            
        } 
    }
}
