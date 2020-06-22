# WASD Movement

## Description
This mechanic shows how to implement simple movement in 2D for a user's character using the WASD keys.

## Implementation
    using UnityEngine;

    public class Movement : MonoBehaviour
    {
        public KeyCode jumpKey;

        public float speed = 10f;

        void Update()
        {
            Vector3 pos = transform.position;

            if (Input.GetKey("w"))
            {
                pos.y += speed * Time.deltaTime;
            }
            if (Input.GetKey("s"))
            {
                pos.y -= speed * Time.deltaTime;
            }
            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }


            transform.position = pos;
        }
    }

