using UnityEngine;
using UnityEngine.InputSystem;

public class Overworld_JoystickTutorialDisappear : MonoBehaviour
{
    
    public PlayerInput InputActions;

    public Vector2 startAmt;

    private float delay = 1;

    private bool canCheck = false;
    
    void Start()
    {
        startAmt = InputActions.currentActionMap.actions[0].ReadValue<Vector2>();
    }
    
    // Update is called once per frame
    void Update()
    {
        DelayCounter();
        CheckAmount();
    }

    void DelayCounter()
    {
        if (canCheck) return;
        delay = delay - Time.deltaTime;
        if (delay <= 0)
        {
            canCheck = true;
        }
    }
    
    void CheckAmount()
    {
        if (!canCheck) return;
        
        var input = InputActions.currentActionMap.actions[0].ReadValue<Vector2>();
        if (input != startAmt && input != Vector2.zero)
        {
            if (Mathf.Abs(input.x) > 0 || Mathf.Abs(input.y) > 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    
}
