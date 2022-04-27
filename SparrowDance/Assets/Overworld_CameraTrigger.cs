using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Overworld_CameraTrigger : MonoBehaviour
{

    public OVerworld_CameraController CameraController;
    
    public int newCamPosition;
    public float newCamSize;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CameraController.movingCamera = true;
            CameraController.resizeCamera = true;
            CameraController.MoveTo = newCamPosition;
            CameraController.CameraSize = newCamSize;
        }
    }
    
}
