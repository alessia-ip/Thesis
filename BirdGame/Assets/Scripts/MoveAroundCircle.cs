using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAroundCircle : MonoBehaviour
{
    private int beat = 0;

    public List<string> npcActionsList;
    public List<string> playerActionsList;

    public bool isNPC;

    //NPC vars
    public TextAsset _npcFile;

    public GameObject Npc;

    public GameObject moveToMe;

    public bool IsMoving;
    
    private void Awake()
    {
        
        if (isNPC)
        {
            //get full actions list
            string[] linesInFile = _npcFile.text.Split(',');
            foreach (string line in linesInFile)
            {
                var _finalLineTemp = line.ToLower();
                _finalLineTemp = _finalLineTemp.Replace(" ", "");
                npcActionsList.Add(_finalLineTemp);
            }
        }
        
        moveToMe = this.gameObject;
        
    }

    public void increment()
    {
        beat++;

        
       // GetComponentInChildren<spriteUpdate>().updateSprite();
       
        
        if (beat == 17)
        {
            beat = 1;
        }

        switch (beat)
        {
            case 1:
                InOrOut();
                break;
            case 5:
                InOrOut();
                break;
            case 9:
                InOrOut();
                break;
            case 13:
                InOrOut();
                break;
            case 16:
                MoveToNextCirclePoint();
                break;
            default:
                MoveToNextCirclePoint();
                break;
        }
    }

    private void Update()
    {
        float step =  10 * Time.deltaTime;
        if (this.transform.position != moveToMe.transform.position && IsMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToMe.transform.position, step);
        }
        
        // Check if the position is approximately equal.
        if (Vector3.Distance(transform.position, moveToMe.transform.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            this.gameObject.transform.position = moveToMe.transform.position;
            this.gameObject.transform.parent = moveToMe.transform;
            IsMoving = false;

        }
        
    }

    private void MoveToNextCirclePoint()
    {
        
        this.gameObject.GetComponentInChildren<Animator>().SetTrigger("JumpTrigger");
        
        
        var currentPoint = this.gameObject.transform.parent.GetComponent<CirclePoint>();
        if (currentPoint.nextPoint != null)
        {
            this.gameObject.transform.parent = null;
            moveToMe = currentPoint.nextPoint;
            /*this.gameObject.transform.position = currentPoint.nextPoint.transform.position;
            this.gameObject.transform.parent = currentPoint.nextPoint.transform;*/
        }
    }

    private void InOrOut()
    {
        
        var currentPoint = this.gameObject.transform.parent.GetComponent<CirclePoint>();
        
        if (isNPC)
        {
            switch (npcActionsList[0])
            {
                case "up":
                    if (currentPoint.outPoint != null)
                    {
                        this.gameObject.transform.parent = null;
                        this.gameObject.transform.position = currentPoint.outPoint.transform.position;
                        this.gameObject.transform.parent = currentPoint.outPoint.transform;
                    }
                    npcActionsList.RemoveAt(0);
                    break;
                case "down":
                    if (currentPoint.inPoint != null)
                    {
                        this.gameObject.transform.parent = null;
                        this.gameObject.transform.position = currentPoint.inPoint.transform.position;
                        this.gameObject.transform.parent = currentPoint.inPoint.transform;
                    }
                    npcActionsList.RemoveAt(0);
                    break;
                case "hold":
                    npcActionsList.RemoveAt(0);
                    break;
                default:
                    break;
            }
        }
        else //this is if you're the player character
        {
            
           
            
            switch (playerActionsList[0])
            {
                case "up":
                    if (currentPoint.outPoint != null)
                    {
                        this.gameObject.transform.parent = null;
                        this.gameObject.transform.position = currentPoint.outPoint.transform.position;
                        this.gameObject.transform.parent = currentPoint.outPoint.transform;
                    }
                    playerActionsList.RemoveAt(0);
                    break;
                case "down":
                    if (currentPoint.inPoint != null)
                    {
                        this.gameObject.transform.parent = null;
                        this.gameObject.transform.position = currentPoint.inPoint.transform.position;
                        this.gameObject.transform.parent = currentPoint.inPoint.transform;
                    }
                    playerActionsList.RemoveAt(0);
                    break;
                case "hold":
                    playerActionsList.RemoveAt(0);
                    break;
                default:
                    break;
            }

            if (Npc.transform.parent == this.transform.parent) //this is if you end up overlapping by accident!!!
            {
                currentPoint = this.gameObject.transform.parent.GetComponent<CirclePoint>();
                if (currentPoint.nextPoint != null)
                {
                    this.gameObject.transform.parent = null;
                    this.gameObject.transform.position = currentPoint.nextPoint.transform.position;
                    this.gameObject.transform.parent = currentPoint.nextPoint.transform;
                }
                else
                {
                    this.gameObject.transform.parent = null;
                    this.gameObject.transform.position = currentPoint.outPoint.transform.position;
                    this.gameObject.transform.parent = currentPoint.outPoint.transform;
                }
            }
            
        }
        
        
    }
    
    
    
}
