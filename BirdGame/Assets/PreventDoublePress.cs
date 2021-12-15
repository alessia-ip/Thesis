using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreventDoublePress : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.GetComponent<Button>().interactable = false;
        Invoke(nameof(reset), 5);
    }

    private void OnEnable()
    {
        Invoke(nameof(reset), 10);
    }

    public void trigger()
    {
        this.gameObject.GetComponent<Button>().interactable = false;
        Invoke(nameof(reset), 10);
    }

    public void reset()
    {
        this.gameObject.GetComponent<Button>().interactable = true;
    }
}
