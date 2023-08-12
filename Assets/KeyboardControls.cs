// GENERATED AUTOMATICALLY FROM 'Assets/New Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace AM
{
    public class @KeyboardControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @KeyboardControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""New action map"",
            ""id"": ""e7c53fe5-b84f-4be3-bbf2-e2adbb3f2615"",
            ""actions"": [
                {
                    ""name"": ""middle mouse"",
                    ""type"": ""Button"",
                    ""id"": ""504e9395-d727-4e5d-a950-4c1dc8b14990"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""E"",
                    ""type"": ""Button"",
                    ""id"": ""50822d47-377e-42c6-b656-f38b7b9b46d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3486f95b-7a07-4f0d-93c4-7edf60a90d53"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""middle mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5e0b3bf-0f89-44af-9b7f-f4d8efbda389"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // New action map
            m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
            m_Newactionmap_middlemouse = m_Newactionmap.FindAction("middle mouse", throwIfNotFound: true);
            m_Newactionmap_E = m_Newactionmap.FindAction("E", throwIfNotFound: true);
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

        // New action map
        private readonly InputActionMap m_Newactionmap;
        private INewactionmapActions m_NewactionmapActionsCallbackInterface;
        private readonly InputAction m_Newactionmap_middlemouse;
        private readonly InputAction m_Newactionmap_E;
        public struct NewactionmapActions
        {
            private @KeyboardControls m_Wrapper;
            public NewactionmapActions(@KeyboardControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @middlemouse => m_Wrapper.m_Newactionmap_middlemouse;
            public InputAction @E => m_Wrapper.m_Newactionmap_E;
            public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
            public void SetCallbacks(INewactionmapActions instance)
            {
                if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
                {
                    @middlemouse.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMiddlemouse;
                    @middlemouse.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMiddlemouse;
                    @middlemouse.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMiddlemouse;
                    @E.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnE;
                    @E.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnE;
                    @E.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnE;
                }
                m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @middlemouse.started += instance.OnMiddlemouse;
                    @middlemouse.performed += instance.OnMiddlemouse;
                    @middlemouse.canceled += instance.OnMiddlemouse;
                    @E.started += instance.OnE;
                    @E.performed += instance.OnE;
                    @E.canceled += instance.OnE;
                }
            }
        }
        public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
        public interface INewactionmapActions
        {
            void OnMiddlemouse(InputAction.CallbackContext context);
            void OnE(InputAction.CallbackContext context);
        }
    }
}
