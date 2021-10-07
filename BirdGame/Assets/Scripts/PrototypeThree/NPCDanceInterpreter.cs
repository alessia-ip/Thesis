using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDanceInterpreter : MonoBehaviour
{

    public string _vector2Positions;
    public string _danceMoves;
    
    public TextAsset _vector2File;
    public TextAsset _danceFile;

    public List<Vector2> _vec2PosList;
    public List<int> _danceMovesList;

    public GameObject NPC;
    public GameObject NPCGhost;

    public AxialGridManager _grid;
    
    // Start is called before the first frame update
    void Start()
    {
        _vector2File = Resources.Load<TextAsset>("DancePositionFiles/" + _vector2Positions);
        _danceFile = Resources.Load<TextAsset>("DanceMoveFiles/" + _danceMoves);
        
        Debug.Log(_danceFile.text);
        Debug.Log(_vector2File.text);
        
        InterpretPositions();
        InterpretMoves();
    }

    void InterpretPositions()
    {
        string[] linesInFile = _vector2File.text.Split('\n');
        foreach (string line in linesInFile)
        {
            if (!line.Contains("///"))
            {
                int one = Int32.Parse(line.Split(',')[0]);
                int two = Int32.Parse(line.Split(',')[1]);
                Vector2 temp = new Vector2(one, two);
                _vec2PosList.Add(temp);
                if (_vec2PosList.Count == 1)
                {
                    NPC.transform.position = _grid.tileArray[one, two].transform.position;
                    NPC.GetComponent<TilePosition>().axialCoordinates = temp;
                    NPCGhost.transform.position = _grid.tileArray[one, two].transform.position;
                    NPCGhost.GetComponent<TilePosition>().axialCoordinates = temp;
                }
            }
        }
    }

    void InterpretMoves()
    {
        string[] linesInFile = _danceFile.text.Split('\n');
        foreach (string line in linesInFile)
        {
            if (!line.Contains("///"))
            {
                int one = Int32.Parse(line.Split('-')[0]);
                _danceMovesList.Add(one);
            }
        }
    }
    
}
