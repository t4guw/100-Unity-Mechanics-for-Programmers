# Smooth Camera Follow

## Description
This mechanic shows how to make a camera smoothly follow a player/object.

## Implementation
There are a few steps that need to be taken in the Unity editor.
1. Choose an object for the camera to follow. This could be the player or any other GameObject.
2. Attach the below code as as script to the desired camera.
3. Drap and drop the object chosen in step 1 to the target variable in the Unity editor.

A few notes to consider:
- The offset can be changed to position the camera around the player as desired.
- If working in 3D, comment out the transform.LookAt(target), and change LateUpdate() to FixedUpdate()

###
    using UnityEngine;

    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        public float smoothSpeed = 0.125f;
        public Vector3 offset;

        private void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            //transform.LookAt(target);
        }
    }
