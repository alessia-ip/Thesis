using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ds_playerDirectionDetermination : MonoBehaviour
{

    public bool isWith;
    
    public void LeftOrRight(bool _isWith)
    {
        //left should be with
        //right should be against
        isWith = _isWith;
    }
    
}
