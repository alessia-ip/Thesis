using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceChangeIcon : MonoBehaviour
{

    public DanceInfo _Dance;

    public ChangeIcon _ChangeIcon;
    
    public Sprite S;
    public Sprite C;
    public Sprite P;

    // Update is called once per frame
    void Awake()
    {
        if (_Dance.affection > _Dance.excitement && 
            _Dance.affection > _Dance.contentment)
        {
            _ChangeIcon.iconToChangeTo = P;
        }
         else if (_Dance.excitement > _Dance.affection && 
            _Dance.excitement > _Dance.contentment)
        {
            _ChangeIcon.iconToChangeTo = S;
        }
        else if (_Dance.contentment > _Dance.excitement && 
                  _Dance.contentment > _Dance.affection)
        {
            _ChangeIcon.iconToChangeTo = C;
        }
        else
        {
            _ChangeIcon.iconToChangeTo = S;
        }
    }
}
