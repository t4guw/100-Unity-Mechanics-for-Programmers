# Camera Zoom in 2D

## Description
This mechanic shows how to implement camera zoom in 2D. This would be useful when developing a 2D game,
such as a platformer, or top-down view game. The implementation below shows how to use both the 
scroll wheel and arrow keys to control the camera zoom. The mouse scroll wheel is a common method for
controlling camera zoom, and is implemented using the default keybinds in Unity. Additionally,
the below code has been implemented using the up and down arrow keys for users that do not have
a mouse scroll wheel. However, the arrow keys can easily be replaced with another set of keys.

## Implementation
Ensure the camera property "Projection" is set to orthographic. The "zoomFactor" variable controls how much
the camera will zoom in per scroll or key press. 
The "minZoom" variable controls the closest the player can zoom in. The "maxZoom" variable controls the furthest the player can zoom
out. The "zoomLerpSpeed" controls the speed at which the camera zooms in and increasing its value 
will speed up the rate at which the camera smoothly zooms, and vice versa.

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Zoom : MonoBehaviour
    {
        private Camera cam;

        private float targetZoom;
        private float zoomFactor = 3f;
        [SerializeField]private float zoomLerpSpeed = 10f;
        [SerializeField]private float minZoom = 2f;
        [SerializeField]private float maxZoom = 20f;
        private float currentZoom;

        void Start()
        {
            cam = Camera.main;
            targetZoom = cam.orthographicSize;
        }

        void Update()
        {
            currentZoom = -Input.GetAxis("Mouse ScrollWheel");

            if (Input.GetKey(KeyCode.UpArrow)) {
                currentZoom += 0.1f;
            }

            if (Input.GetKey(KeyCode.DownArrow)) {
                currentZoom -= 0.1f;
            }

            targetZoom -= currentZoom * zoomFactor;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
        }
    }
