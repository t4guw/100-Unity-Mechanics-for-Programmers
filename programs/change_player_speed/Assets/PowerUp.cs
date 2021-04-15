using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float newSpeed;
    private float oldSpeed;
    public float duration = 5f;
    private float timeLeft;
    private Movement player = null;
    private bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.GetComponent<Movement>();
        oldSpeed = player.speed;
        player.speed = newSpeed;
        timeLeft = duration;
        pickedUp = true;
        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        if (pickedUp)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                player.speed = oldSpeed;
                Destroy(this.gameObject);
            }
        }
    }
}
