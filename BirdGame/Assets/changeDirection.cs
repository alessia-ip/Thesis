using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDirection : MonoBehaviour
{
    // Update is called once per frame

    void Update()
    {
        if (transform.parent != null && transform.parent.name.Contains("Point"))
        {
            var dir = transform.parent.GetComponent<CirclePoint>().isLeft;
            if (dir)
            {
                this.transform.localScale = new Vector3(-Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            }
            else
            {
                this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            }
        } 
    }
}
