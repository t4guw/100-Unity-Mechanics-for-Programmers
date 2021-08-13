# Enemy Follow Player 2D

## Description
This mechanic will show how to make an enemy chase a player in 2D.

## Implementation
Unity currently does not have any built-in tools to support pathfinding in 2D. However, there are 3rd party resources to help implement pathfinding, such
as the [A* Pathfinding Project](https://arongranberg.com/astar/). This resources allows you to implement pathfinding and dynamic waypoints in 2D without coding.
For simplicity, the implementation below uses the [Vector2.MoveTowards()](https://docs.unity3d.com/ScriptReference/Vector2.MoveTowards.html) method. This will work fine if there is no terrain to move around. To change the speed of the enemy, modify the "speed" variable, and to alter the minimum distance the enemy can get to the player, modify the "minDist" variable.

    using UnityEngine;

    public class EnemyAI : MonoBehaviour
    {
        public GameObject player;
        private float speed = 5f;
        private float minDist = 0.7f;

        private void Update()
        {
            if (Vector2.Distance(transform.position, player.transform.position) > minDist)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
            }
        }
    }

