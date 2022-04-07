using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeIcon : MonoBehaviour
{
    public GameObject spriteIcon;
    public Sprite originalIcon;
    public Sprite iconToChangeTo;

    void Start()
    {
        originalIcon = spriteIcon.GetComponent<SpriteRenderer>().sprite;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            spriteIcon.GetComponent<SpriteRenderer>().sprite = iconToChangeTo;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            spriteIcon.GetComponent<SpriteRenderer>().sprite = originalIcon;
        }
    }
}
