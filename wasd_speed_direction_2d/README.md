# WASD Speed and Direction (2D)  

## Description
This mechenic shows how to implement control over speed and direction in 2D for a user's character using a set of input keys. For example, if a user was controlling a car or other vehicle. The code below shows how to use the W/Up arrow and S/Down arrow keys to speed up and slow down, respectively, while the A/Left Arrow and D/Right Arrow keys turn/rotate the character left and right, respectively. The code can be modified to use any set of keys such as IJKL.

## Implementation
First, ensure the designated object has a RigidBody2D component attached, with gravity set to 0.  

This first snippet of code below shows how to implement control over velocity and direction using the WASD keys.
This is done by directly changing the velocity and the rotation of the game object. However, this method overrides physics elements,
such as friction.
    using UnityEngine;

    public class Speed_Direction : MonoBehaviour {
        public float speed;
        public float rotateSpeed;
        private Rigidbody2D rb2d;

        void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
        }
        

        void Update () {
            // Change Speed
            if (Input.GetKey(KeyCode.W)) {
                speed += 0.1f;
            } else if (Input.GetKey(KeyCode.S)) {
                if (speed - 2 < 0 ) {
                    speed = 0f;
                } else {
                    speed -= 0.1f;
                }
            }

            // Change direction
            if (Input.GetKey(KeyCode.A)) {
                transform.Rotate(0,0,rotateSpeed);
            }
            if (Input.GetKey(KeyCode.D)) {
                transform.Rotate(0,0,-1 * rotateSpeed);
            }
            rb2d.velocity = transform.up * speed;
        }
    }
  
The snippet of code below shows how to control direction and speed by adding forces to the object,
rather than directly changing the velocity. To add friction, alter the "Linear Drag" and "Angular Drag" properties
in the Unity editor.

    using UnityEngine;
    
    public class Speed_Direction_Friction : MonoBehaviour {
        public float speed;
        public float rotateSpeed;
        private Rigidbody2D rb2d;

        public Vector2 movement;

        void Start () {
            b2d = GetComponent<Rigidbody2D> ();
        }
        

        void Update () {
            // Change direction
            if (Input.GetKey(KeyCode.LeftArrow)) {
                transform.Rotate(0,0,rotateSpeed);
                rb2d.AddForce(-transform.right * rotateSpeed);
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                transform.Rotate(0,0,-1 * rotateSpeed);
                rb2d.AddForce(transform.right * rotateSpeed);
            }

            // Change Speed
            if (Input.GetKey(KeyCode.UpArrow)) {
                moveCharacter(transform.up);
            } else if (Input.GetKey(KeyCode.DownArrow)) {
                moveCharacter(-transform.up);
            }

            //movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        void FixedUpdate() {
            //moveCharacter(transform.up);
        }

        void moveCharacter(Vector3 direction) {
            rb2d.AddForce(direction * speed);
        }
    }
