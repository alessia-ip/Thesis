using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial_CameraMovement : MonoBehaviour
{
    public PlayerInput InputActions;

    public Tutorial_CurrentState currentState;
    public Tutorial_StepsCompleted stepsCompleted;
    
    public bool cameraInMotion = false;

    public GameObject cam;
    
    public List<Transform> cameraPositions;
    
    void Start()
    {
        cameraInMotion = true;
        cam.transform.position = cameraPositions[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraInMotion)
        { 
            moveTheCamera();
        }
        else
        {
            Vector2 vec = InputActions.currentActionMap.actions[0].ReadValue<Vector2>();
            Debug.Log(vec);
            int newDir = 0;
            
            if (vec.y == 0) return;
            
            if (vec.y > 0) // up
            {
                newDir = -1;
            } else if (vec.y < 0) //down
            {
                newDir = 1; // <- going 
            }

            if (newDir == -1 && currentState.StateNumber == 1) return; //we don't want to go before the first state
            if (newDir == 1 && currentState.StateNumber == 4) return; //we don't want to go past the last state either
            if (newDir == 1 && currentState.StateNumber == 2 && !stepsCompleted.revealedEmotions) return; //we don't want to advance past the tutorial steps!
            if (newDir == 1 && currentState.StateNumber == 3 && !stepsCompleted.triedACombo) return; //we don't want to advance past the tutorial steps!

            currentState.StateNumber = currentState.StateNumber + newDir;
            cameraInMotion = true;
        }
    }


    void moveTheCamera()
    {
        var NewPos = Vector3.Lerp(
            cam.transform.position,
            cameraPositions[currentState.StateNumber].position,
            0.05f);
        cam.transform.position = NewPos;
        if (Vector3.Distance(cam.transform.position,
            cameraPositions[currentState.StateNumber].position) < 0.5f)
        {
            cameraInMotion = false;
            cam.transform.position = cameraPositions[currentState.StateNumber].position;
        }
    }
    
}
