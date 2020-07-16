# Raycast Shooting in 2D

## Description
This mechanic shows how to implement raycast shooting in 2D. This would be useful when developing a shooter that uses "hitscan," a popular mechanic for shooting, instead of firing projectiles that fly through the air.

## Implementation
The example program was implemented using a line to show the location/effect of the raycast. To do this:
1. Create a line effect (Create > Effects > Line). 
2. Increase Order in Layer
3. Expand the "Positions" property. Index 0 is the starting point for the line, while Index 1 is the ending point. Change the default Index 1 value from Z = 1, to Z = 0, and adjust the X and Y values as desired. 
4. The color can be adjusted as desired, and roundness can be added by increasing the "End Cap Vertices" property. Width of the line can be adjusted with the slider in the inspector. 
5. Enable "Use World Space" to prevent moving the postion.
6. Drag the Line in the hierarchy to make it a child of the object shooting the ray (likely the player).

To make the ray collide with an object, ensure the target object has a BoxCollider2D component attached.

        using UnityEngine;
        using System.Collections;

        public class Shoot : MonoBehaviour
        {
            public LineRenderer lineRenderer;

            private void Update()
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    StartCoroutine(Fire());
                }
            }

            IEnumerator Fire()
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(transform.up, transform.up);

                if (hitInfo)
                {
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, hitInfo.point);
                } else
                {
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, transform.position + transform.up * 100);
                }

                lineRenderer.enabled = true;

                yield return new WaitForSeconds(0.02f);

                lineRenderer.enabled = false;
            }
        }
