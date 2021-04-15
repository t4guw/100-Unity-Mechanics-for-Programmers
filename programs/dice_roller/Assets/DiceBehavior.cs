using UnityEngine;

public class DiceBehavior : MonoBehaviour
{
    static Rigidbody rb;
    public static Vector3 diceVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        diceVelocity = rb.velocity;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector3.zero;

            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);

            transform.position = new Vector3(-7, 5, 0);
            transform.rotation = Quaternion.identity;
            rb.AddForce(transform.up * 500);
            rb.AddForce(transform.right * 500);
            rb.AddTorque(dirX, dirY, dirZ);
        }
    }
}
