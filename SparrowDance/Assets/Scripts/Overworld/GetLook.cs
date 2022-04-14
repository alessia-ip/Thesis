using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GetLook : MonoBehaviour
{
    public bool LookingAtNPC;
    public LayerMask _LayerMask;
    
    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit;
        
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, _LayerMask))
        {
            Debug.Log(hit.collider.gameObject.name);
            
            LookingAtNPC = true;
            
        }
        else
        {
            LookingAtNPC = false;
        }
        
    }
}
