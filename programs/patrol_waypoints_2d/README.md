# Patrol Between Waypoints in 2D

## Description
This mechanic shows how to make an NPC patrol between a set of waypoints in 2D. This could be useful
when implementing an NPC that will patrol along a pre-determined path.

## Implementation
Attach the following script to the desired "NPC." In the empty field with an array of GameObjects,
set the size field to the amount of waypoints that you would like the NPC to patrol, and drag the waypoint objects
into the slots in the order that you would like the NPC to patrol them.


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
