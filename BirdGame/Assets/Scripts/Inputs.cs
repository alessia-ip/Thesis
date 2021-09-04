using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class Inputs : MonoBehaviour
{

    public enum controlScheme
    {
        Gamepad,
        Keyboard
    }

    public controlScheme _controlScheme = controlScheme.Keyboard;
    
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;

    public GamepadButton gUpKey;
    public GamepadButton gDownKey;
    public GamepadButton gLeftKey;
    public GamepadButton gRightKey;
    
    private void Awake()
    {
        SetKeyboardControls();
        SetGamepadControls();
    }

    void SetGamepadControls()
    {
        gUpKey = GamepadButton.North;
        gDownKey = GamepadButton.South;
        gLeftKey = GamepadButton.West;
        gRightKey = GamepadButton.East;
    }

    // Update is called once per frame
    void SetKeyboardControls()
    {
        upKey = KeyCode.W;
        downKey = KeyCode.S;
        leftKey = KeyCode.A;
        rightKey = KeyCode.D;
    }
}
