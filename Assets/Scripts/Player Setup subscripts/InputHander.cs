using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace AM
{
    public class InputHander : MonoBehaviour
    {
        public float horizontal;
        public float vertical;
        public float moveAmount;
        public float mouseX;
        public float mouseY;

        public bool b_input;
        public bool rb_input;
        public bool rt_input;
        public bool lb_input;
        public bool d_pad_Up;
        public bool d_pad_Down;
        public bool d_pad_Left;
        public bool d_pad_Right;
        public bool a_input;
        public bool inventory_input;
        public bool lockOnInput;
        public bool right_Stick_Right_Input;
        public bool right_Stick_Left_Input;
        public bool e_keyboard;


        public bool rollFlag;
        public float rollInputTimer;
        public bool isInteracting;
        public bool sprintFlag;
        public bool comboFlag;
        public bool inventoryFlag;
        public bool lockOnFlag;

        PlayerControls inputActions;
        KeyboardControls keyboardInput;
        PlayerManager playerManager;
        CameraHandler cameraHandler;

       

        Vector2 movementInput;
        Vector2 cameraInput;

        public void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
            cameraHandler = FindObjectOfType<CameraHandler>();
        }



        public void OnEnable()
        {
            if (inputActions == null)
            {
                inputActions = new PlayerControls();
                inputActions.PlayerMovement.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
                inputActions.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();

                
                inputActions.PlayerActions.RB.performed += i => rb_input = true;
                inputActions.PlayerActions.RT.performed += i => rt_input = true;
                inputActions.PlayerActions.LB.performed += i => lb_input = false;
                inputActions.PlayerActions.LB.canceled += i => lb_input = true;
                inputActions.PlayerMovement.DPadRight.performed += i => d_pad_Right = true;
                inputActions.PlayerMovement.DPadLeft.performed += i => d_pad_Left = true;
                inputActions.PlayerMovement.AorX.performed += i => a_input = true;
                inputActions.PlayerMovement.Inventory.performed += i => inventory_input = true;
                inputActions.PlayerActions.lockOn.performed += i => lockOnInput = true;
                inputActions.PlayerMovement.LockOnTargetRight.performed += i => right_Stick_Right_Input = true;
                inputActions.PlayerMovement.LockOnTargetLeft.performed += i => right_Stick_Left_Input = true;
                inputActions.PlayerMovement.E_keyboard.performed += i => e_keyboard = true;



            }

            inputActions.Enable();
        }

        public void OnDisable()
        {
            inputActions.Disable();
        }

        public void TickInput(float delta)
        {
            MoveInput(delta);
            


        }

        private void MoveInput(float delta)
        {
            horizontal = movementInput.x;
            vertical = movementInput.y;
            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
            mouseX = cameraInput.x;
            mouseY = cameraInput.y;
        }



        


    }
}

