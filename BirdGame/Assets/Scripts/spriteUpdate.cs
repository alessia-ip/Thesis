using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteUpdate : MonoBehaviour
{

    public Sprite[] sprites = new Sprite[4];

    private int SpriteNum = 0;
    
    public void updateSprite()
    {
        SpriteNum++;
        if (SpriteNum == 4)
        {
            SpriteNum = 0;
        }

        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[SpriteNum];
    }


}
