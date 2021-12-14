using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePoint : MonoBehaviour
{
    public GameObject outPoint;
    public GameObject inPoint;
    public GameObject nextPoint;


    public bool isLeft;
    
    void OnDrawGizmosSelected()
    {
        if (outPoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, outPoint.transform.position);
        }

        if (inPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, inPoint.transform.position);
        }
        
        if (nextPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, nextPoint.transform.position);
        }
        
       
        
    }
    
}
