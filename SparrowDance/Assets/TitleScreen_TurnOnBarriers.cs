using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen_TurnOnBarriers : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name);
       gameObject.GetComponent<BoxCollider>().isTrigger = false;
    }
}
