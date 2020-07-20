# Enemy Follow Player 2D

## Description
This mechanic will show how to make an enemy chase a player.

## Implementation
Unity currently does not have any built-in tools to support pathfinding in 2D. However, there are 3rd party resources to help implement pathfinding, such
as the [A* Pathfinding Project](https://arongranberg.com/astar/). This resources allows you to implement pathfinding and dynamic waypoints in 2D without coding.
For simplicity, the implementation below uses the Vector2.MoveTowards() method. This will work fine if there is no terrain to move around.

using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    private float speed = 5f;

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > 0.7f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }
    }
}
