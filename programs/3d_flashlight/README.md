# 3D Flashlight

## Description
This mechanic shows how to implement a flashlight in 3D space.

## Implementation
There are several steps that need to be done in the Unity Editor.
To view how to set up the character movement in 3D, refer to the [First Person Movement 3D](https://github.com/t4guw/100-Unity-Mechanics-for-Programmers/tree/master/programs/first_person_movement_3d) mechanic.

   1. Create or download desired flashlight object.
   2. Attach the Flashlight Script to the flashlight object.
   3. Create a Spot Light and make it a child of the flashlight.
   4. Change the position and rotation of the light to be in the head of the flashlight.
   5. Set the flashlight as a child of the main camera.

    using UnityEngine;

    public class FlashlightScript : MonoBehaviour
    {
        bool flashlightOn;

        void Start()
        {
            transform.GetChild(0).gameObject.SetActive(false);
            flashlightOn = false;
            RenderSettings.reflectionIntensity = 0.2f;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (flashlightOn)
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    flashlightOn = false;
                    RenderSettings.reflectionIntensity = 0.2f;
                }
                else
                {
                    transform.GetChild(0).gameObject.SetActive(true);
                    flashlightOn = true;
                    RenderSettings.reflectionIntensity = 0.5f;
                }
            }
        }
    }