using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleScreen_Controller : MonoBehaviour
{

    public PlayerInput InputActions;

    public GameObject character;
    
    private Vector3 smoothInputMovement;
    private Vector3 movementDirection;
    public float movementSpeed = 3f;
    public float movementSmoothingSpeed = 1f;
    
    
    // Start is called before the first frame update
    void FixedUpdate()
    {
        GetMovement();
        MoveThePlayer();
    }


    void MoveThePlayer()
    {
        Vector3 movement = smoothInputMovement * movementSpeed * Time.deltaTime;
        character.transform.position = character.transform.position + movement;
    }
    
    void GetMovement()
    {
        var input = InputActions.currentActionMap.actions[0].ReadValue<Vector2>();
        var rawInputMovement = new Vector3(input.x, input.y, 0);
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);
        Debug.Log(input);
    }


}
