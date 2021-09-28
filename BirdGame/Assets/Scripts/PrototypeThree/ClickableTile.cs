using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour
{
    public bool clickable = false;

    public MoveGhost _moveGhost;

    private void Start()
    {
        _moveGhost = GameObject.Find("GameManager").GetComponent<MoveGhost>();
    }

    private void OnMouseDown()
    {
        if (clickable == true)
        {
            Debug.Log(this.gameObject.name);
            _moveGhost.ClickedTile = this.gameObject;
        }
    }
}
