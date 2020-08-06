# Parallax Infinite Background in 2D

## Description
This mechanic shows how to implement an infinite background scrolling for a 2D platformer. The example program uses the jump and WASD movement from previous mechanics to demonstrate the Parallax effect.  

The background image can be found [here](https://www.deviantart.com/stormandy/art/Wip-Parallax-Background-341233890)

## Implementation
There are several steps that need to be completed in the Unity Editor
1. First import an image that will be used as the background. Ensure the left and right sides align to create a seamless effect.
2. Create a sprite renderer object and attach the image. Change the "Draw Mode" to "Tiled."
3. Use the Rect Tool to horizontally scale the object to at least 3 times the camera size
4. Attach the following script to the background object.

        using UnityEngine;

        public class Parallax : MonoBehaviour
        {
            [SerializeField] private Vector2 parallaxEffectMultiplier;
            [SerializeField] private bool infiniteHorizontal;
            [SerializeField] private bool infiniteVertical;

            private Transform cameraTransform;
            private Vector3 lastCameraPosition;
            private float textureUnitSizeX;
            private float textureUnitSizeY;

            void Start()
            {
                cameraTransform = Camera.main.transform;
                lastCameraPosition = cameraTransform.position;
                Sprite sprite = GetComponent<SpriteRenderer>().sprite;
                Texture2D texture = sprite.texture;
                textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
                textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
            }

            void LateUpdate()
            {
                Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
                transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
                lastCameraPosition = cameraTransform.position;

                if (infiniteHorizontal)
                {
                    if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX)
                    {
                        float offsetPositionX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX;
                        transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);
                    }
                }

                if (infiniteVertical)
                {
                    if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= textureUnitSizeY)
                    {
                        float offsetPositionY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
                        transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY);
                    }
                }    
            }
        }


5. In the inspector, modify the "Parallax Effect Multiplier" variable to the desired values. For horizontally scrolling sprites (such as the ground), check the "Infinite Horizontal" variable, and for vertically scrolling sprites (such as clouds), check the "Infinite Vertical" variable.
