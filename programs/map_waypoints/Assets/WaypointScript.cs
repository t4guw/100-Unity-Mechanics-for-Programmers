using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public GameObject map;
    public GameObject waypoint;
    Vector3 waypointLoc;
    bool MapActive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (MapActive)
            {
                map.SetActive(false);
                MapActive = false;
            }
            else
            {
                map.SetActive(true);
                MapActive = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            waypoint.SetActive(false);
        }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 50f);
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.name == "Map")
            {
                waypointLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                waypointLoc.z = 0f;
                waypoint.transform.position = waypointLoc;
                waypoint.SetActive(true);
            }
        }
    }
}