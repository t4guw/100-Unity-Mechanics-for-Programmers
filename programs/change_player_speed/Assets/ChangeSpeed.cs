using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    public float newSpeed;
    private float oldSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        oldSpeed = collision.GetComponent<Movement>().speed;
        collision.GetComponent<Movement>().speed = newSpeed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Movement>().speed = oldSpeed;
    }
}
