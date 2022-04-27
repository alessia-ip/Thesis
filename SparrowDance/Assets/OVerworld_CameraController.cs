using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVerworld_CameraController : MonoBehaviour
{
    public List<Transform> cameraPositions;
    public GameObject camera;
    public bool movingCamera = false;
    public bool resizeCamera = false;
    public int MoveTo;
    public float CameraSize; 
    
    // Update is called once per frame
    void Update()
    {
        if (movingCamera)
        {
            var pos = Vector3.Slerp
            (
                camera.transform.position,
                cameraPositions[MoveTo].position,
                0.01f
            );

            camera.transform.position = pos;
            
            if (Vector3.Distance(
                    camera.transform.position,
                    cameraPositions[MoveTo].position) <
                0.005f)
            {
                camera.transform.position = cameraPositions[MoveTo].position;
                movingCamera = false;
            }
        }

        if (resizeCamera)
        {
            var size = lerpFloat(camera.GetComponent<Camera>().orthographicSize,
                CameraSize,
                0.01f);
            
            camera.GetComponent<Camera>().orthographicSize = size;

            if (Mathf.Abs(camera.GetComponent<Camera>().orthographicSize - CameraSize) < 0.005f)
            {
                camera.GetComponent<Camera>().orthographicSize = CameraSize;
                resizeCamera = false;
            }
        }
    }

    float lerpFloat(float a, float b, float t)
    {
        var l = a + (b - a) * t;
        return l;
    }
    
}
