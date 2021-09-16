using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Phase _turnPhase;

    public MovesPlanned _movesPlanned;

    public GameObject moveBackground;
    public GameObject arrowKey;

    
    private int prevSize = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (_turnPhase._dancePhase == Phase.DancePhase.Planning)
        {
            movePlannerVisuals();
        }
    }

    void movePlannerVisuals()
    {
        if (_movesPlanned.PlannedMoves.Count > 0)
        {
            moveBackground.SetActive(true);
            var bgRect = moveBackground.GetComponent<RectTransform>();
            Vector2 rectSize = new Vector2(35 * _movesPlanned.PlannedMoves.Count + 40, bgRect.rect.height); 
            bgRect.sizeDelta = rectSize;
            //Debug.Log(rectSize);
            if (_movesPlanned.PlannedMoves.Count > prevSize)
            {
                Debug.Log(_movesPlanned.PlannedMoves.Count);
                prevSize = _movesPlanned.PlannedMoves.Count;
                var newArrow = Instantiate(arrowKey);
                newArrow.transform.SetParent(bgRect.transform, false);
                newArrow.GetComponent<RectTransform>().anchoredPosition = new Vector3(35 * prevSize, 0, 0);
                Debug.Log(_movesPlanned.PlannedMoves[prevSize-1].Method +"");
                switch (_movesPlanned.PlannedMoves[prevSize-1].Method + "")
                {
                    case "Void exeMoveOneNorth()":
                        return;
                    case "Void exeMoveOneEast()":
                        newArrow.GetComponent<RectTransform>().eulerAngles = new Vector3(0,0, -90);
                        return;
                    case "Void exeMoveOneSouth()":
                        newArrow.GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,-180);
                        return;
                    case "Void exeMoveOneWest()":
                        newArrow.GetComponent<RectTransform>().eulerAngles = new Vector3(0,0, -270);
                        return;
                }
            }
            
        }
        else
        {
            moveBackground.SetActive(false);
            foreach (RectTransform child in moveBackground.GetComponent<RectTransform>().transform) {
                GameObject.Destroy(child.gameObject);
            }
            prevSize = 0;

        }
    }
    
}
