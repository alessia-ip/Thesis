using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectObjectDetails : MonoBehaviour
{

    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("DetailCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit " + hit.collider.gameObject.name);
        }
    }
}
