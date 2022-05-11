using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Outro_TempChangeMemory : MonoBehaviour
{

    public Sprite Regular;
    public Sprite Vibe;
    public GameObject Memory;
    public DanceInfo _info;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_info.vibe >= 85)
        {
            Memory.GetComponent<Image>().sprite = Vibe;
        }
        else
        {
            Memory.GetComponent<Image>().sprite = Regular;
        }
    }

    
}
