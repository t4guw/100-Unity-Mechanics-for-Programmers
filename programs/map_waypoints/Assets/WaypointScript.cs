using System.Collections.Generic;
using UnityEngine;

public class WaypointScript : MonoBehaviour
{
    public GameObject map;
    public GameObject waypointPrefab;
    Vector3 waypointLoc;
    List<GameObject> waypoints;
    bool mapActive;
    

    float timer;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mapActive)
            {
                map.SetActive(false);
                mapActive = false;
            }
            else
            {
                map.SetActive(true);
                mapActive = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            timer = Time.time;
            GameObject tempWaypoint = waypoints[waypoints.Count - 1];
            waypoints.Remove(tempWaypoint);
            Destroy(tempWaypoint);
        }

        if (Input.GetKey(KeyCode.Delete) && (Time.time - timer) >= 1f)
        {

            int waypointCount = waypoints.Count;
            for (int i = 0; i < waypointCount; i++)
            {
                GameObject tempWaypoint = waypoints[waypoints.Count - 1];
                waypoints.Remove(tempWaypoint);
                Destroy(tempWaypoint);
            }
        }

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 50f);
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.name == "Map")
            {
                GameObject newWaypoint = Instantiate(waypointPrefab, map.transform);
                waypointLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                waypointLoc.z = 0f;
                newWaypoint.transform.position = waypointLoc;
                waypoints.Add(newWaypoint);
            }

            if (Input.GetMouseButtonDown(1) && hit.collider.tag == "Waypoint")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}