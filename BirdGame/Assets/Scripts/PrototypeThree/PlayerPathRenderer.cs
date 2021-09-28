using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPathRenderer : MonoBehaviour
{
    public List<Vector3> pathPoints;

    public GameObject player;
    public GameObject playerGhost;

    public LineRenderer playerLineRenderer;
    
    private void Start()
    {
        pathPoints = new List<Vector3>();
    }

 
    public void AddPointToPath()
    {
        if (pathPoints.Count == 0)
        {
            pathPoints.Add(player.transform.position);
        }
        pathPoints.Add(playerGhost.transform.position);
        DrawPath();
    }

    public void DrawPath()
    {
        playerLineRenderer.positionCount = pathPoints.Count;
        for (int i = 0; i < pathPoints.Count; i++)
        {
            playerLineRenderer.SetPosition(i, pathPoints[i]);
        }
    }
    
    public void ClearPath()
    {
        pathPoints.Clear();
        pathPoints.Add(player.transform.position);
    }
    
}
