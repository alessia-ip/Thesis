using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TemptReset : MonoBehaviour
{

    public DanceInfo danceInfoReset;
    
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
            danceInfoReset.vibe = 0;
        }       
    }
}
