# Move Camera with Arrow Keys and Mouse

## Description
This mechanic shows how to move the camera using the arrow keys and/or mouse. This mechanic
is similar to camera movement in the popular MOBA League of Legends.

## Implementation
Attach the following script to the camera. The script also implements using the space bar to reset the camera back to
coordinates (0,0,0) for ease of use, but can be changed to reset back to player location.

    using UnityEngine;

    public class CameraController : MonoBehaviour
    {
        public float panSpeed = 20f;
        public float panBorderThickness = 30f;
        public Vector2 panLimit;

        private void Update()
        {
            Vector3 pos = transform.position;

            if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                pos.y += panSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
            {
                pos.y -= panSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                pos.x += panSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
            {
                pos.x -= panSpeed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                pos.x = 0;
                pos.y = 0;
            }

            pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
            pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

            transform.position = pos;
        }
    }
