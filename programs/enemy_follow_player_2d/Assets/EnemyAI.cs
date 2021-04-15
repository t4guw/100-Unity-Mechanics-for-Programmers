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
