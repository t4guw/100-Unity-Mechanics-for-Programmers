using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private bool isJumping = false;
    private float moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Input();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Input()
    {
        moveDirection = UnityEngine.Input.GetAxis("Horizontal");
        if (UnityEngine.Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }

        isJumping = false;
    }
}
