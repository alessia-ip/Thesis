using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject rightBound;
    public GameObject leftBound;

    public GameObject rightWingOut;
    public GameObject rightWingIn;
    public GameObject rightWingJump;
    public GameObject rightWingDown;
    
    public GameObject leftWingOut;
    public GameObject leftWingIn;
    public GameObject leftWingJump;
    public GameObject leftWingDown;

    public bool canjump = true;
    
    public GameObject wowBackground;
    
    public bool inRange = false;
    
    // Update is called once per frame
    void Update()
    {

        if (canjump == true)
        {
            
            
            
            if (Input.GetKey(KeyCode.LeftArrow) && 
                this.transform.position.x > leftBound.transform.position.x )
            {
                var newpos = new Vector2(this.transform.position.x  - (1.5f * Time.deltaTime), 
                    this.transform.position.y);
                this.transform.position = newpos;
                Debug.Log(("left"));
                wingsWalkLeft();
            
            } else if (Input.GetKey(KeyCode.RightArrow) && 
                       this.transform.position.x < rightBound.transform.position.x )
            {
                var newpos = new Vector2(this.transform.position.x + (1.5f * Time.deltaTime), 
                    this.transform.position.y );
                this.transform.position = newpos;
            
                wingsWalkRight();

            } else if (Input.GetKeyDown(KeyCode.Space) )
            {
                canjump = false;
                jump();
            }
            else 
            {
                standing();
            }
            
            
        }
       
        
        
        
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        wowBackground.SetActive(true);
        inRange = true;
        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        wowBackground.SetActive(true);
        inRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        wowBackground.SetActive(false);
        inRange = false;
    }

    private void wingsWalkLeft()
    {
        leftWingDown.SetActive(false);
        leftWingIn.SetActive(true);
        leftWingOut.SetActive(false);
        leftWingJump.SetActive(false);
        
        rightWingDown.SetActive(false);
        rightWingIn.SetActive(false);
        rightWingOut.SetActive(true);
        rightWingJump.SetActive(false);
    }    
    
    private void wingsWalkRight()
    {
        leftWingDown.SetActive(false);
        leftWingIn.SetActive(false);
        leftWingOut.SetActive(true);
        leftWingJump.SetActive(false);
        
        rightWingDown.SetActive(false);
        rightWingIn.SetActive(true);
        rightWingOut.SetActive(false);
        rightWingJump.SetActive(false);
    }    
    
    private void standing()
    {
        leftWingDown.SetActive(true);
        leftWingIn.SetActive(false);
        leftWingOut.SetActive(false);
        leftWingJump.SetActive(false);
        
        rightWingDown.SetActive(true);
        rightWingIn.SetActive(false);
        rightWingOut.SetActive(false);
        rightWingJump.SetActive(false);
    }

    void jump()
    {
        this.gameObject.GetComponent<Animator>().Play("PlayerJump");
    }
    

}
