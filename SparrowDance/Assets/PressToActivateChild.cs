using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToActivateChild : MonoBehaviour
{
    public GameObject childToActivate;
    public KeyCode key;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            childToActivate.SetActive(true);
        }
    }
}
