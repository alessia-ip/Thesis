using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private bool one = false;
    private bool two = false;
    private bool three = false;
    private bool four = false;

    public GameObject TextOne;
    public GameObject TextTwo;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            one = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            two = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            three = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            four = true;
        }

        if (one && two && three && four)
        {
            TextOne.SetActive(false);
            TextTwo.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
