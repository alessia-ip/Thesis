using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetDistance : MonoBehaviour
{
    public GameObject player;

    public float dist;
    public List<float> distances;
    public float avgDistance;
    
    public GameObject distText;

    public GameObject distCanv;
    
    public bool first = true;
    
    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(player.transform.position, this.gameObject.transform.position);
        Debug.Log(dist);

        if (player.transform.parent == null || transform.parent == null)
        {
            return;
        }
        
        if(player.transform.parent.gameObject == this.transform.parent.GetComponent<CirclePoint>().nextPoint
        || this.transform.parent.gameObject == player.transform.parent.GetComponent<CirclePoint>().nextPoint)
        {
            distText.GetComponent<TMP_Text>().text = "Hey neighbor! Glad to see you!";
        } else if (player.transform.parent.gameObject == this.transform.parent.GetComponent<CirclePoint>().inPoint
            ||player.transform.parent.gameObject == this.transform.parent.GetComponent<CirclePoint>().outPoint)
        {
            distText.GetComponent<TMP_Text>().text = "You're almost close enough to reach!";
        } else if (avgDistance >= 5)
        {
            distText.GetComponent<TMP_Text>().text = "...are you trying to avoid me?";
        } else if (avgDistance < 5 && avgDistance > 3)
        {
            distText.GetComponent<TMP_Text>().text = "I think we're both a bit out of practice here!";
        } else if (avgDistance <= 3 && avgDistance > 0.5f)
        {
            distText.GetComponent<TMP_Text>().text = "Just like old times! That's the spirit";
        }else
        {
            distText.GetComponent<TMP_Text>().text = "Let's bop!";
        }

        if (AudioListener.pause && !first)
        {
            DistCanvOn();
        }
        else
        {
            DistCanvOff();
        }
        
    }

    public void getAvg()
    {
        distances.Add(dist);
        float gettingAvg = 0;
        for (int i = 0; i < distances.Count - 1; i++)
        {
            gettingAvg = gettingAvg + distances[i];
        }

        gettingAvg = gettingAvg / distances.Count;

        avgDistance = gettingAvg;

    }

    public void clearAvg()
    {
        distances.Clear();
        avgDistance = 0;
    }

    public void DistCanvOn()
    {
        distCanv.SetActive(true);
    }
    
    public void DistCanvOff()
    {
        distCanv.SetActive(false);
    }
}
