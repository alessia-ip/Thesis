using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIButtons : MonoBehaviour
{

    public Sprite[] _spr;
    public int sprNum = 0;

    private void Start()
    {
        this.gameObject.GetComponent<Image>().sprite = _spr[sprNum];
    }

   public void NextType()
    {
        sprNum++;
        if (sprNum > 2)
        {
            sprNum = 0;
        }
        this.gameObject.GetComponent<Image>().sprite = _spr[sprNum];
    }
    
    
}
