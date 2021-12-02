using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStartPosition : MonoBehaviour
{

    public GameObject startPosition;


    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = startPosition.transform.position;
        this.transform.parent = startPosition.transform;
    }
    
}
