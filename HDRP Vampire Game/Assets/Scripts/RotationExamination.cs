using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationExamination : MonoBehaviour
{

    public GameObject rotatableObj;
    private float speed = 0.5f;
    private bool setToNormal = false;
    private Quaternion quatZero = new Quaternion(0, 0, 0, 1);
    
    // Update is called once per frame
    void Update()
    {
        //If the object is currently interactable, allow it to be rotated by the player
        if (!setToNormal)
        {
            //The horizontal axis is the L/R arrow keys on keyboard
            //It is the joystick on an Xbox controller (make sure this is the RIGHT joystick in the input manager)
            if (Input.GetAxis("Horizontal") != 0) //this is just to check it is not 'at rest'
            {
                rotatableObj.transform.Rotate(
                    0, 
                    -Input.GetAxis ("Horizontal") * speed, //this rotates it horizontally based on the input float
                    0f, 
                    Space.World); //this is so that the up & down is consistent, and not based on rotation
            }
        
            //The horizontal axis is the U/D arrow keys on keyboard
            //It is the joystick on an Xbox controller (make sure this is the RIGHT joystick in the input manager)
            if (Input.GetAxis("Vertical") != 0) //this is just to check it is not 'at rest'
            {
                rotatableObj.transform.Rotate(Input.GetAxis("Vertical") * speed, 0, 0f, Space.World);
            }
        }
        
        //TODO change this input to work with controller, not just keyboard
        //consider having inputs in a separate file or input manager file?
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setToNormal = true;
        }

        if (setToNormal == true)
        {
            //rotate back to the OG position (quatZero) 
            //TODO this is hella slow. Pls speed this up
            rotatableObj.transform.rotation = Quaternion.RotateTowards( rotatableObj.transform.rotation, quatZero, speed);
            
            //if we've come back to the OG position, allow it to be manipulated again
            if (rotatableObj.transform.rotation == quatZero)
            {
                setToNormal = false;
            }
        }
        
    }
    
}
