# Grappling Hook in 2D

## Description
This mechanic shows how to implement a grappling hook in 2D.

## Implementation
There are several steps that need to be completed in the Unity Editor:
1. Create a sprite renderer object, and add a RigidBody2D, BoxCollider2D, DistanceJoint2D, and LineRenderer components.
2. Adjust the width for the LineRenderer as needed.
3. If you would like to change the color for the LineRenderer, create a new material and drag and drop it to the material property.
4. If you would like the grappling hook to collide with objects check "Enable Collision" in the DistanceJoint2D component.
5. Add the following script to the object. Drag and drop the appropriate object/components to the correct fields in the inspector. 

        using UnityEngine;

        public class Grappler : MonoBehaviour
        {
            public Camera mainCamera;
            public LineRenderer _lineRenderer;
            public DistanceJoint2D _distanceJoint;

            void Start()
            {
                _distanceJoint.enabled = false;
            }

            void Update()
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    _lineRenderer.SetPosition(0, mousePos);
                    _lineRenderer.SetPosition(1, transform.position);
                    _distanceJoint.connectedAnchor = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    _distanceJoint.enabled = true;
                    _lineRenderer.enabled = true;
                } else if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    _distanceJoint.enabled = false;
                    _lineRenderer.enabled = false;
                }

                if (_distanceJoint.enabled)
                {
                    _lineRenderer.SetPosition(1, transform.position);
                }
            }
        }
