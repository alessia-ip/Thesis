// GENERATED AUTOMATICALLY FROM 'Assets/DanceControlScheme.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DanceControlScheme : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DanceControlScheme()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DanceControlScheme"",
    ""maps"": [
        {
            ""name"": ""DanceMap"",
            ""id"": ""b97a561c-0979-44ef-8014-a3d786e0842d"",
            ""actions"": [
                {
                    ""name"": ""DownInput"",
                    ""type"": ""Button"",
                    ""id"": ""14c9e896-8572-4837-a448-57dfb78886bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up Input"",
                    ""type"": ""Button"",
                    ""id"": ""c092d72e-a23e-4aa6-85b2-ec5f7d7d85e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left Input"",
                    ""type"": ""Button"",
                    ""id"": ""0f97791d-8524-49fe-87a9-3bbccd7600d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right Input"",
                    ""type"": ""Button"",
                    ""id"": ""c2bcde4d-38c4-442a-8e66-2027bdc5008c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c4a97443-3464-4d06-9591-2e9ec742bee1"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a66cf97-b9ef-447b-a2ff-80e709881017"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4dbe480-8ceb-408c-8704-9b611a8f70b0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9666646-ef60-440e-a790-6767e4b2dd9d"",
                    ""path"": ""<XInputController>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""128cb6ad-ee8b-40a5-8b61-b61290af207d"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fb8424b-6161-47b6-be12-aeb1bb012165"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb9f1bac-b427-40c8-9c93-ef7bbb2ae625"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96dd0a6e-22d5-4537-9aa3-3201257a069a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e13b69f3-1a5e-4f8c-ac83-80e5ac2d6929"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c952410a-6204-4265-ba26-dbfba8543bb8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Main"",
            ""bindingGroup"": ""Main"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // DanceMap
        m_DanceMap = asset.FindActionMap("DanceMap", throwIfNotFound: true);
        m_DanceMap_DownInput = m_DanceMap.FindAction("DownInput", throwIfNotFound: true);
        m_DanceMap_UpInput = m_DanceMap.FindAction("Up Input", throwIfNotFound: true);
        m_DanceMap_LeftInput = m_DanceMap.FindAction("Left Input", throwIfNotFound: true);
        m_DanceMap_RightInput = m_DanceMap.FindAction("Right Input", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // DanceMap
    private readonly InputActionMap m_DanceMap;
    private IDanceMapActions m_DanceMapActionsCallbackInterface;
    private readonly InputAction m_DanceMap_DownInput;
    private readonly InputAction m_DanceMap_UpInput;
    private readonly InputAction m_DanceMap_LeftInput;
    private readonly InputAction m_DanceMap_RightInput;
    public struct DanceMapActions
    {
        private @DanceControlScheme m_Wrapper;
        public DanceMapActions(@DanceControlScheme wrapper) { m_Wrapper = wrapper; }
        public InputAction @DownInput => m_Wrapper.m_DanceMap_DownInput;
        public InputAction @UpInput => m_Wrapper.m_DanceMap_UpInput;
        public InputAction @LeftInput => m_Wrapper.m_DanceMap_LeftInput;
        public InputAction @RightInput => m_Wrapper.m_DanceMap_RightInput;
        public InputActionMap Get() { return m_Wrapper.m_DanceMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DanceMapActions set) { return set.Get(); }
        public void SetCallbacks(IDanceMapActions instance)
        {
            if (m_Wrapper.m_DanceMapActionsCallbackInterface != null)
            {
                @DownInput.started -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnDownInput;
                @DownInput.performed -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnDownInput;
                @DownInput.canceled -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnDownInput;
                @UpInput.started -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnUpInput;
                @UpInput.performed -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnUpInput;
                @UpInput.canceled -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnUpInput;
                @LeftInput.started -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnLeftInput;
                @LeftInput.performed -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnLeftInput;
                @LeftInput.canceled -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnLeftInput;
                @RightInput.started -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnRightInput;
                @RightInput.performed -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnRightInput;
                @RightInput.canceled -= m_Wrapper.m_DanceMapActionsCallbackInterface.OnRightInput;
            }
            m_Wrapper.m_DanceMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DownInput.started += instance.OnDownInput;
                @DownInput.performed += instance.OnDownInput;
                @DownInput.canceled += instance.OnDownInput;
                @UpInput.started += instance.OnUpInput;
                @UpInput.performed += instance.OnUpInput;
                @UpInput.canceled += instance.OnUpInput;
                @LeftInput.started += instance.OnLeftInput;
                @LeftInput.performed += instance.OnLeftInput;
                @LeftInput.canceled += instance.OnLeftInput;
                @RightInput.started += instance.OnRightInput;
                @RightInput.performed += instance.OnRightInput;
                @RightInput.canceled += instance.OnRightInput;
            }
        }
    }
    public DanceMapActions @DanceMap => new DanceMapActions(this);
    private int m_MainSchemeIndex = -1;
    public InputControlScheme MainScheme
    {
        get
        {
            if (m_MainSchemeIndex == -1) m_MainSchemeIndex = asset.FindControlSchemeIndex("Main");
            return asset.controlSchemes[m_MainSchemeIndex];
        }
    }
    public interface IDanceMapActions
    {
        void OnDownInput(InputAction.CallbackContext context);
        void OnUpInput(InputAction.CallbackContext context);
        void OnLeftInput(InputAction.CallbackContext context);
        void OnRightInput(InputAction.CallbackContext context);
    }
}
