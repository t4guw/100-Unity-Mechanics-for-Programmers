using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBlock : MonoBehaviour
{
    public float speedMod = 0.5f;
    public float gravityMod = 0.5f;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale *= gravityMod;
        other.GetComponent<PlayerMovement>().moveSpeed *= speedMod;
        other.GetComponent<PlayerMovement>().jumpForce *= speedMod;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale /= gravityMod;
        other.GetComponent<PlayerMovement>().moveSpeed /= speedMod;
        other.GetComponent<PlayerMovement>().jumpForce /= speedMod;
    }

}
