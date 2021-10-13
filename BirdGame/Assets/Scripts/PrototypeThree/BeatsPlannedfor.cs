using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BeatsPlannedFor : MonoBehaviour
{
    public int BeatsToPlanFor = 10;
    public int beatsRemaining;

    public GameObject energy;
    
    public int BeatsRemaining
    {
        get
        {
            return beatsRemaining;
        } 
        set
        {
            beatsRemaining = value;
            updateEnergyMeter();
        }
    }

    private void Awake()
    {
        BeatsRemaining = BeatsToPlanFor;
        updateEnergyMeter();
    }

    public void updateEnergyMeter()
    {
        energy.GetComponent<TextMeshProUGUI>().text = BeatsRemaining + "/" + BeatsToPlanFor + " beats left!";
    }
}
