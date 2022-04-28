using UnityEngine;
using UnityEngine.InputSystem;

public class Overworld_JoystickTutorialDisappear : MonoBehaviour
{
    
    public PlayerInput InputActions;
    
    // Update is called once per frame
    void Update()
    {
        var input = InputActions.currentActionMap.actions[0].ReadValue<Vector2>();
        if (Mathf.Abs(input.x) > 0 || Mathf.Abs(input.y) > 0)
        {
            Destroy(this.gameObject);
        }
    }
}
