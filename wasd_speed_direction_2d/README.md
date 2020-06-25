# WASD Speed and Direction (2D)  

## Description
This mechenic shows how to implement control over speed and direction in 2D for a user's character using a set of input keys. For example, if a user was controlling a car or other vehicle. The code below shows how to use the W and S keys to speed up and slow down, respectively, while the A and D keys turn/rotate the character left and right, respectively. The code can be modified to use any set of keys such as IJKL or arrow keys.

## Implementation
    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using System.Collections.Generic;

    public class Speed_Direction : MonoBehaviour {
        public float mHeroSpeed;
        public float kHeroRotateSpeed;
        private Rigidbody2D rb2d;

        void Start () {
          rb2d = GetComponent<Rigidbody2D> ();
        }


        void Update () {
            // Change Speed
            if (Input.GetKey(KeyCode.W)) {
                mHeroSpeed += 0.1f;
            } else if (Input.GetKey(KeyCode.S)) {
                if (mHeroSpeed - 2 < 0 ) {
                    mHeroSpeed = 0f;
                } else {
                    mHeroSpeed -= 0.1f;
                }
            }

            // Change direction
            if (Input.GetKey(KeyCode.A)) {
                transform.Rotate(0,0,kHeroRotateSpeed);
            }
            if (Input.GetKey(KeyCode.D)) {
                transform.Rotate(0,0,-1 * kHeroRotateSpeed);
            }
            rb2d.velocity = transform.up * mHeroSpeed;

        }

    }
