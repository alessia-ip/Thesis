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

        if (!setToNormal)
        {
            if (Input.GetAxis("Horizontal") != 0)
            {
                rotatableObj.transform.Rotate(0, -Input.GetAxis ("Horizontal") * speed, 0f, Space.World);
            }
        
            if (Input.GetAxis("Vertical") != 0)
            {
                rotatableObj.transform.Rotate(Input.GetAxis("Vertical") * speed, 0, 0f, Space.World);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setToNormal = true;
        }

        if (setToNormal == true)
        {
            rotatableObj.transform.rotation = Quaternion.RotateTowards( rotatableObj.transform.rotation, quatZero, speed);
            if (rotatableObj.transform.rotation == quatZero)
            {
                setToNormal = false;
            }
        }
        
    }
    
}
