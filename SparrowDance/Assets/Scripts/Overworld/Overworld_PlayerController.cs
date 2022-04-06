using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Overworld_PlayerController : MonoBehaviour
{
    public PlayerInput InputActions;
    public Camera mainCamera;
    private Vector3 movementDirection;
    private Vector3 smoothInputMovement;
    public Rigidbody playerRigidbody;
    
    [Header("Movement Settings")]
    public float movementSpeed = 3f;
    public float turnSpeed = 0.1f;
    public float movementSmoothingSpeed = 1f;

    [Header("Animation Components")] 
    public Animator playerAnimator;

    #region movement 


    void FixedUpdate()
    {
        GetMovement();
        MoveThePlayer();
        TurnThePlayer();
    }

    void MoveThePlayer()
    {
        Vector3 movement = CameraDirection(movementDirection) * movementSpeed * Time.deltaTime;
        if (InputActions.currentActionMap.actions[0].ReadValue<Vector2>() == Vector2.zero)
        {
            movement = Vector3.zero;
        }
        playerRigidbody.MovePosition(transform.position + movement);
    }
    
    // Update is called once per frame
    void GetMovement()
    {
        var input = InputActions.currentActionMap.actions[0].ReadValue<Vector2>();
        Debug.Log(input);
        var rawInputMovement = new Vector3(input.x, 0, input.y);
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
        UpdateMovementData(smoothInputMovement);

    }
    
    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }
    
    Vector3 CameraDirection(Vector3 movementDirection)
    {
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        
        return cameraForward * movementDirection.z + cameraRight * movementDirection.x; 
   
    }
    
    void TurnThePlayer()
    {
        if(movementDirection.sqrMagnitude > 0.01f)
        {

            Quaternion rotation = Quaternion.Slerp(playerRigidbody.rotation,
                Quaternion.LookRotation (CameraDirection(movementDirection)),
                turnSpeed);

            playerRigidbody.MoveRotation(rotation);

        }
    }
    #endregion
    
    #region animation

    void Update()
    {
        TriggerWalkingAnimation();
    }

    void TriggerWalkingAnimation()
    {
        var input = InputActions.currentActionMap.actions[0].ReadValue<Vector2>();
        if (input == Vector2.zero)
        {
            playerAnimator.SetBool("IsWalking", false);
        }
        else
        {
            playerAnimator.SetBool("IsWalking", true);
        }
        
    }
    
    #endregion
}
