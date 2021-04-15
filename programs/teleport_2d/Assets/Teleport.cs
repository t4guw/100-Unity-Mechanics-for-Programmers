using UnityEngine;

public class Teleport : MonoBehaviour
{
    public int index;
    public SpriteRenderer destination;
    public SpriteRenderer player;
    private bool canTeleport = false;

    void OnTriggerEnter2D(Collider2D other) {
        canTeleport = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canTeleport)
        {
            player.transform.position = destination.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        canTeleport = false;
    }
}
