using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class LookAtPlayer : MonoBehaviour
{
    public Rig headRig;

    void Start()
    {
        headRig.weight = 0;
    }


    void EnableHead()
    {
        var newWeight = Mathf.MoveTowards(headRig.weight, 1, 0.05f);
        headRig.weight = newWeight;
        
        if(headRig.weight == 1) CancelInvoke();
    }
    
    void DisableHead()
    {
        var newWeight = Mathf.MoveTowards(headRig.weight, 0, 0.05f);
        headRig.weight = newWeight;
        
        if(headRig.weight == 0) CancelInvoke();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CancelInvoke();
            InvokeRepeating(nameof(EnableHead), 0, 0.1f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CancelInvoke();
            InvokeRepeating(nameof(DisableHead), 0, 0.1f);
        }
    }
}
