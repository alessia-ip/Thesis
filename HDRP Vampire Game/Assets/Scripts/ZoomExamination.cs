using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomExamination : MonoBehaviour
{
    public GameObject zoomableObj;
    private bool setToNormal = false;
    private float speed = 0.5f;
    public float maxSize;
    public float minSize;
    private Vector3 origSize = new Vector3(1, 1, 1);
    
    void Update()
    {
        if (!setToNormal)
        {
            if (Input.GetKey(KeyCode.Q) &&
                zoomableObj.transform.localScale.x < maxSize)
            {
                Debug.Log(zoomableObj.transform.localScale);
                var maxVect = new Vector3(maxSize, maxSize, maxSize);
                zoomableObj.transform.localScale = Vector3.MoveTowards(
                    zoomableObj.transform.localScale,
                    maxVect, 
                    Time.deltaTime * speed);
            } else if (Input.GetKey(KeyCode.E) &&
                       zoomableObj.transform.localScale.x > minSize)
            {
                var minVect = new Vector3(minSize, minSize, minSize);
                zoomableObj.transform.localScale = Vector3.MoveTowards(
                    zoomableObj.transform.localScale,
                    minVect, 
                    Time.deltaTime * speed);
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
          
            zoomableObj.transform.localScale = Vector3.MoveTowards(
                zoomableObj.transform.localScale,
                origSize, 
                Time.deltaTime * speed);
            
            //if we've come back to the OG size, allow it to be manipulated again
            if (zoomableObj.transform.localScale == origSize)
            {
                setToNormal = false;
            }
        }
        
    }
}
