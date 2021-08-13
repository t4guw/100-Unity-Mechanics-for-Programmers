using UnityEngine;

public class Patrol : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    private float WPradius = 0.2f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }
}
