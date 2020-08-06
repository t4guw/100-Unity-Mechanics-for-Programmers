# First Person Movement 3D

## Description
This mechanic shows how to implement movement and looking from first person perspective in 3D.

## Implementation
There are several steps that need to be done in the Unity Editor.
1. Create an empty game object that will serve as the player.
2. Add a cylinder/capsule component and a "character controller" component as children to the object created in the previous step. Remove the capsule collider from the cylinder component.
3. Drag the main camera to be a child of the object created in step 1. Reset the transform component and move it torwards the top of the object (increase y value).
4. To implement looking around using the mouse, attach the following script:

        using UnityEngine;

        public class MouseLook : MonoBehaviour
        {
            public float mouseSens = 100f;
            public Transform playerBody;
            float xRotation = 0f;

            void Start()
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            void Update()
            {
                float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);
                transform.localRotation = Quaternion.Euler(xRotation, 0 ,0);

                playerBody.Rotate(Vector3.up * mouseX);
            }
        }

5. Create an empty game object as a child of the object in step 1. This will serve as the check to see if the player is standing on the ground. Position it towards the bottom of the object.
6. Attach the following script to the player implement movement, using WASD and the Space bar to jump. Attach the appropriate objects to the fields in the inspector.

        using UnityEngine;

        public class PlayerMovement : MonoBehaviour
        {
            public CharacterController controller;
            public float speed = 12f;
            public float gravity = -9.81f;
            public float jumpHeight = 3f;

            public Transform groundCheck;
            public float groundDistance = 4f;
            public LayerMask groundMask;

            Vector3 velocity;
            bool isGrounded;

            void Update()
            {
                isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

                if (isGrounded && velocity.y < 0)
                {
                    velocity.y = -2f;
                }

                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                Vector3 move = transform.right * x + transform.forward * z;

                controller.Move(move * speed * Time.deltaTime);

                if(Input.GetButtonDown("Jump"))
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }

                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);
            }
        }
