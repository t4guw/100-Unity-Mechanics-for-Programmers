# Reset Level/Scene

## Description 
This mechanic shows how to implement resetting a scene/level on keypress and falling out of a screen.
The example progam is implemented using WASD movement on a platform.

## Implementation
There are several steps that need to be completed in the Unity Editor:
1. Create a new sprite renderer 2D object that will serve as the player. Add a RigidBody2D component and BoxCollider2D component.
2. Create a new sprite renderer 2D object that will serve as the platform. Add a BoxCollider2D component.
3. Add the following script to the player object from step 1:

        using UnityEngine;
        using UnityEngine.SceneManagement;

        public class ResetOnKeypress : MonoBehaviour
        {
            void Update()
            {
                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene("Level1");
                }
            }
        }
4. Create a new object that will serve as the boundary which will reset the level when the player falls off the platform and goes outside the bottom camera boundary. Position it at the bottom edge of the camera. Add a BoxCollider2D component, enable the "Is Trigger" property, and add the following script to the new object:

        using UnityEngine;
        using UnityEngine.SceneManagement;

        public class ResetOnFall : MonoBehaviour
        {
            void OnTriggerEnter2D()
            {
                SceneManager.LoadScene("Level1");
            }
        }



