using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{
    public bool clickable = false;
    
    public MoveGhost _moveGhost;
    public BeatsPlannedFor _beatsPlannedFor;

    private void Start()
    {
        _moveGhost = GameObject.Find("PlayerGameManager").GetComponent<MoveGhost>();
        _beatsPlannedFor = GameObject.Find("PlayerGameManager").GetComponent<BeatsPlannedFor>();
    }

    private void OnMouseDown()
    {
        if (clickable == true && _beatsPlannedFor.BeatsRemaining > 0)
        {
            Debug.Log(this.gameObject.name);
            _moveGhost.ClickedTile = this.gameObject;
            _beatsPlannedFor.BeatsRemaining--;
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.gameObject.tag == "Unwalkable")
        {
            Destroy(this.gameObject);
        }
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Unwalkable")
        {
            Destroy(this.gameObject);
        }
    }
    
}
