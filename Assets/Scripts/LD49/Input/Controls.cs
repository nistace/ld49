// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace LD49.Input
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""28ce01c8-574d-4693-b15d-2d8a7e3c9437"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""dd5f9563-9093-481b-9dff-e9b4199c94e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""9ea9a1b7-2325-4645-baf6-3505888360ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""3a1db2bf-2b62-499a-b08f-4db8add730c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""5a29211a-3a47-4c4e-be91-2332dd67d4ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseStableCircuit"",
                    ""type"": ""Button"",
                    ""id"": ""7bdd17c9-b2ce-483d-9205-44b130c12526"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Value"",
                    ""id"": ""0f90f2b7-c9b6-4b12-b872-1b5eb29b504c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Telekinesis"",
                    ""type"": ""Button"",
                    ""id"": ""f67d3f8d-d188-43ac-900f-2db01ac0331b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1ea33fbe-f139-4135-be21-91eeb2d40f7f"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcef8c6a-3248-4ca6-a13c-5caf5c759dd6"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d436cf19-72ff-4a4e-a9ed-2d42811a1122"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""580a680a-4ca2-4afb-a422-8d3f7d75a41b"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6aa41d37-8199-4439-b517-921fb2b9b2df"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c23b93f-838d-44c4-8e82-98e4f02909da"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6748431-a003-4513-92a9-76507a87ca5f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9fff4a13-cf4f-45ce-b0a7-3141b8cac37d"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseStableCircuit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d0587c3e-0717-45fc-97c5-10f773619ffa"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ead7c81a-6d7f-4e34-be74-8a0475baa0e7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Telekinesis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""9886c7c2-0e19-446a-9eeb-5c2d7a93c9a4"",
            ""actions"": [
                {
                    ""name"": ""RestartLevel"",
                    ""type"": ""Button"",
                    ""id"": ""c16324a4-3be9-450e-be15-6c7d09ccb9a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""139ad407-d2cf-4463-b8fa-6ce9981acf52"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RestartLevel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
            m_Player_Left = m_Player.FindAction("Left", throwIfNotFound: true);
            m_Player_Right = m_Player.FindAction("Right", throwIfNotFound: true);
            m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
            m_Player_UseStableCircuit = m_Player.FindAction("UseStableCircuit", throwIfNotFound: true);
            m_Player_Mouse = m_Player.FindAction("Mouse", throwIfNotFound: true);
            m_Player_Telekinesis = m_Player.FindAction("Telekinesis", throwIfNotFound: true);
            // Game
            m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
            m_Game_RestartLevel = m_Game.FindAction("RestartLevel", throwIfNotFound: true);
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

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_Jump;
        private readonly InputAction m_Player_Left;
        private readonly InputAction m_Player_Right;
        private readonly InputAction m_Player_Fire;
        private readonly InputAction m_Player_UseStableCircuit;
        private readonly InputAction m_Player_Mouse;
        private readonly InputAction m_Player_Telekinesis;
        public struct PlayerActions
        {
            private @Controls m_Wrapper;
            public PlayerActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Jump => m_Wrapper.m_Player_Jump;
            public InputAction @Left => m_Wrapper.m_Player_Left;
            public InputAction @Right => m_Wrapper.m_Player_Right;
            public InputAction @Fire => m_Wrapper.m_Player_Fire;
            public InputAction @UseStableCircuit => m_Wrapper.m_Player_UseStableCircuit;
            public InputAction @Mouse => m_Wrapper.m_Player_Mouse;
            public InputAction @Telekinesis => m_Wrapper.m_Player_Telekinesis;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                    @Left.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                    @Left.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                    @Left.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeft;
                    @Right.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                    @Right.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                    @Right.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRight;
                    @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                    @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                    @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                    @UseStableCircuit.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseStableCircuit;
                    @UseStableCircuit.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseStableCircuit;
                    @UseStableCircuit.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUseStableCircuit;
                    @Mouse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouse;
                    @Mouse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouse;
                    @Mouse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouse;
                    @Telekinesis.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTelekinesis;
                    @Telekinesis.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTelekinesis;
                    @Telekinesis.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTelekinesis;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @Left.started += instance.OnLeft;
                    @Left.performed += instance.OnLeft;
                    @Left.canceled += instance.OnLeft;
                    @Right.started += instance.OnRight;
                    @Right.performed += instance.OnRight;
                    @Right.canceled += instance.OnRight;
                    @Fire.started += instance.OnFire;
                    @Fire.performed += instance.OnFire;
                    @Fire.canceled += instance.OnFire;
                    @UseStableCircuit.started += instance.OnUseStableCircuit;
                    @UseStableCircuit.performed += instance.OnUseStableCircuit;
                    @UseStableCircuit.canceled += instance.OnUseStableCircuit;
                    @Mouse.started += instance.OnMouse;
                    @Mouse.performed += instance.OnMouse;
                    @Mouse.canceled += instance.OnMouse;
                    @Telekinesis.started += instance.OnTelekinesis;
                    @Telekinesis.performed += instance.OnTelekinesis;
                    @Telekinesis.canceled += instance.OnTelekinesis;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);

        // Game
        private readonly InputActionMap m_Game;
        private IGameActions m_GameActionsCallbackInterface;
        private readonly InputAction m_Game_RestartLevel;
        public struct GameActions
        {
            private @Controls m_Wrapper;
            public GameActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @RestartLevel => m_Wrapper.m_Game_RestartLevel;
            public InputActionMap Get() { return m_Wrapper.m_Game; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
            public void SetCallbacks(IGameActions instance)
            {
                if (m_Wrapper.m_GameActionsCallbackInterface != null)
                {
                    @RestartLevel.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRestartLevel;
                    @RestartLevel.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRestartLevel;
                    @RestartLevel.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRestartLevel;
                }
                m_Wrapper.m_GameActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @RestartLevel.started += instance.OnRestartLevel;
                    @RestartLevel.performed += instance.OnRestartLevel;
                    @RestartLevel.canceled += instance.OnRestartLevel;
                }
            }
        }
        public GameActions @Game => new GameActions(this);
        public interface IPlayerActions
        {
            void OnJump(InputAction.CallbackContext context);
            void OnLeft(InputAction.CallbackContext context);
            void OnRight(InputAction.CallbackContext context);
            void OnFire(InputAction.CallbackContext context);
            void OnUseStableCircuit(InputAction.CallbackContext context);
            void OnMouse(InputAction.CallbackContext context);
            void OnTelekinesis(InputAction.CallbackContext context);
        }
        public interface IGameActions
        {
            void OnRestartLevel(InputAction.CallbackContext context);
        }
    }
}
