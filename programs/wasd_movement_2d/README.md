# WASD Movement (2D)

## Description
This mechanic shows how to implement movement in 2D for a user's character using a set of input keys. The code below is implemented using the WASD and arrow keys, common sets for many games. However, it can be modified to incorporate/utilize any set of keys, such as IJKL.

## Implementation
The following code shows how to implement 2D character movement using WASD keys. The "speed" variable can be adjusted to change the speed at which the character moves. Another speed variable could be introduced if the developer wanted to create different speeds for different directions, such as moving faster forwards than backwards. Ensure a RigidBody2D component has been added to the GameObject with gravity set to 0.

    using UnityEngine;

    public class Movement : MonoBehaviour
    {
        public float speed = 10f;

        void Update()
        {
            Vector3 pos = transform.position;

            if (Input.GetKey(KeyCode.W))
            {
                pos.y += speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                pos.y -= speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                pos.x += speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                pos.x -= speed * Time.deltaTime;
            }

            transform.position = pos;
        }
    }

The above code can be slightly modified to utilize a different set of keys, such as the arrow keys, as follows:

    using UnityEngine;

    public class Movement : MonoBehaviour
    {
        public float speed = 10f;

        void Update()
        {
            Vector3 pos = transform.position;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                pos.y += speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                pos.y -= speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                pos.x += speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                pos.x -= speed * Time.deltaTime;
            }

            transform.position = pos;
        }
    }
