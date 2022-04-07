using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overworld_DetectCharacter : MonoBehaviour
{
    [SerializeField] private GameObject characterTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Front")
        {
            Debug.Log("Entered trigger");
            characterTrigger = other.gameObject;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Front")
        {
            Debug.Log("Exit trigger");
            characterTrigger = null;
        }
    }
}
