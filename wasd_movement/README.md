# WASD Movement

## Description
This mechanic shows how to implement movement in 2D for a user's character using a set of input keys. The code below is implemented using the WASD keys, a common set for many games. 

## Implementation
    using UnityEngine;

    public class Movement : MonoBehaviour
    {
        public KeyCode jumpKey;

        public float speed = 10f;

        void Update()
        {
            Vector3 pos = transform.position;

            // "w" can be replaced with any key
            // this section moves the character up
            if (Input.GetKey("w"))
            {
                pos.y += speed * Time.deltaTime;
            }

            // "s" can be replaced with any key
            // this section moves the character down
            if (Input.GetKey("s"))
            {
                pos.y -= speed * Time.deltaTime;
            }

            // "d" can be replaced with any key
            // this section moves the character right
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }

            // "a" can be replaced with any key
            // this section moves the character left
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }


            transform.position = pos;
        }
    }


