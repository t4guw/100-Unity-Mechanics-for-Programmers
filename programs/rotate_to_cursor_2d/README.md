# Rotate Object to Cursor in 2D

## Description
This mechanic shows how to rotate an object towards a cursor, but can be modified to rotate towards any object. This could be extremely useful when developing a top-down shooter, or when you want objects to constantly look at a player.

## Implementation
First ensure the player has a Rigidbody2D component attached to it.

    using UnityEngine;

    public class RotatePlayer : MonoBehaviour
    {
        public Camera cam;
        Vector2 mousePos;
        public Rigidbody2D rb2d;

        private void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();   
        }

        void Update()
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        void FixedUpdate()
        {
            Vector2 lookDirection = mousePos - new Vector2(transform.position.x, transform.position.y);
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            rb2d.rotation = angle;
        }
    }
