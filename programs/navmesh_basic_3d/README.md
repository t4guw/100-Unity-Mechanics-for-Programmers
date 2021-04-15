# Navmesh (Basic) in 3D

## Description
This mechanic shows how to move an object from one point to another using Unity Navmeshes.
It shows how to move between set points, and also how to move to a mouse click.

## Implementation
Most of the steps for this mechanic are done in the Unity Editor.
1. First create a 3D "Plane" object and scale it to the desired size. Adjust camera position/rotation as needed to face the plane.
2. At the top bar, go to Window" -> AI ->  Navigation
3. Select the plane from step 1, and go to the "Object" tab under Navigation, and check "Navigation Static." Keep Navigation Area as "Walkable." 
4. Go to the "Bake" tab and click "Bake."
5. Create a "Cube" or "Sphere" object that will serve as your "player". Adjust position and scale as needed.
6. To change the color of the floor/plane and player, create a "Material" in the Assets folder and change the "Albedo" property in the inspector. Attach
the new material to the desired object (plane or player).
7. Add a "Nav Mesh Agent" component to the player object from step 5.
8. Attach the following script to the player object:

        using UnityEngine;
        using UnityEngine.AI;

        public class Move : MonoBehaviour
        {
            [SerializeField] Transform destination;

            NavMeshAgent navMeshAgent;

            void Start()
            {
                navMeshAgent = this.GetComponent<NavMeshAgent>();

                if(navMeshAgent == null)
                {
                    Debug.LogError("nav mesh agent component not attached");
                } else
                {
                    SetDestination();
                }
            }

            private void SetDestination()
            {
                if (destination != null)
                {
                    Vector3 targetVector = destination.transform.position;
                    navMeshAgent.SetDestination(targetVector);
                }
            }
        }

9. Create another sphere/cube that will serve as the destination (point where the player will move to). 
10. In the inspector, drag and drop the new object from step 9 to the "Destination" field in the script component from step 8.
11. To add the feature of clicking to move to a point, add the following script, and drag and drop the the Main Camera and Nav Mesh Agent component to the fields in the inspector.

        using UnityEngine;
        using UnityEngine.AI;

        public class PlayerController : MonoBehaviour
        {
            public Camera cam;

            public NavMeshAgent agent;

            void Update()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        agent.SetDestination(hit.point);
                    }
                }
            }
        }

12. To add a wall, create a new 3D cube. Position and scale it to the desired location/size to represent a wall between the two objects.
13. Go to the Navigation tab and select the new object from the previous step. Go to the Object tab, and select the "Navigation Static" option.
14. Go back to the Floor/plane and Re-bake the navigation mesh.
15. If you do not want your player to be able to go on top of the wall or go over it, ensure that the "Navigation Area" is set to "Not Walkable" under the Wall object's Navigation. Re-bake the Navmesh from the Plane object. This is helpful if your player is able to jump.
16. To create distance between the player and wall as the player walks by (make it so the player does not hug the wall so tightly), add a Nav Mesh Obstacle component to the wall object. To add more space around the wall, increase the size of the Nav Mesh Obstacle. Ensure the "Carve" option is selected so that the Nav Mesh Obstacle carves a hole in the navmesh.
