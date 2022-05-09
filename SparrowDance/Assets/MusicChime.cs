using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChime : MonoBehaviour
{

    public AudioSource musicChimeAudSource;
    public BoxCollider box1;
    public BoxCollider box2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            musicChimeAudSource.Play();
            box1.enabled = false;
            box2.enabled = false;
        }

    }
}
