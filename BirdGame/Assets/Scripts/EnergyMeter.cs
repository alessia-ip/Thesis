using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour
{
    public int maxEnergy = 10;
    public int currentEnergy;

    public GameObject energy;
    
    public int CurrentEnergy
    {
        get
        {
            return currentEnergy;
        } 
        set
        {
            currentEnergy = value;
            updateEnergyMeter();
            
        }
    }

    private void Awake()
    {
        currentEnergy = maxEnergy;
        updateEnergyMeter();
    }

    public void updateEnergyMeter()
    {
        energy.GetComponent<TextMeshProUGUI>().text = currentEnergy + "/" + maxEnergy + " energy.";
    }
    
}
