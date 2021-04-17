using UnityEngine;

public class DiceBehavior : MonoBehaviour
{
    public Vector3 rollDicePos;
    Rigidbody rb;
    public Vector3 diceVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        diceVelocity = rb.velocity;
        if (Input.GetKeyDown(KeyCode.R))
        {            
            rb.velocity = Vector3.zero;

            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);

            transform.position = rollDicePos;
            transform.rotation = Quaternion.identity;
            rb.AddForce(transform.up * 500);
            rb.AddForce(transform.right * 500);
            rb.AddTorque(dirX, dirY, dirZ);
        }
    }
}
