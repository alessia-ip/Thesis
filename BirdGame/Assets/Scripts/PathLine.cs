using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLine : MonoBehaviour
{
   public List<Vector3> lineRendPoints = new List<Vector3>();
   private int prevLength = 0;
   public LineRenderer line;

   public GameObject player;
   public GameObject playerGhost;


   public void NewPoint()
   {
      if (prevLength == 0)
      {
         NewLine();
      }
      prevLength++;
      line.positionCount = prevLength;
      lineRendPoints.Add(new Vector3(playerGhost.transform.position.x, playerGhost.transform.position.y, -5));
      for (int i = 0; i < prevLength; i++){
         //Debug.Log(lineRendPoints[i]);
         line.SetPosition(i, lineRendPoints[i]);
      }
   }

   public void NewLine()
   {
      lineRendPoints.Clear();
      prevLength = 1;
      line.positionCount = prevLength;
      lineRendPoints.Add(new Vector3(player.transform.position.x, player.transform.position.y, -5));
      line.SetPosition(0, lineRendPoints[0]);
   }
   
   
}
