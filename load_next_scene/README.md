# Load Next Scene

## Description
This mechanic will show how to load the next scene or go to the next level. This could be used to
go to a different/next level in a 2D platformer.

## Implementation
First, ensure you have multiple scenes to switch between. Also, go to build settings, and ensure the scenes are in the correct order and all desired scenes are added. The code below uses the "W" key to
go to the next level when standing in front of a "door" in the level, similar to a 2D platformer. Ensure that "using UnityEngine.SceneManagement" is added, and the "door" has "Is Trigger" enabled.   

If wanting to go to the next level without having to press W, and just load the next level on colliding with the door, change "OnTriggerStay2D" to "OnTriggerEnter2D".  

You can also load a scene by name, rather than using the scene index that is found in build settings.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    using UnityEngine.SceneManagement;

    public class NextLevel : MonoBehaviour
    {
        public int index;
        void OnTriggerStay2D(Collider2D other) {
            if (other.CompareTag("Player") && Input.GetKey(KeyCode.W)) {
                SceneManager.LoadScene(index);
            }
        }
    }
