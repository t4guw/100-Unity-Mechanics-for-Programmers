# Reflect Off Walls in 2D

## Description
This mechanic will show how to reflect an object off walls using [Vector3.Reflect](https://docs.unity3d.com/ScriptReference/Vector3.Reflect.html). For more realistic collisions/interactions use Physics2D materials and their "Bounciness" property.

## Implementation
Ensure a Rigidbody2D component and BoxCollider2D component have been attached to the object that will be bouncing.
Also ensure a BoxCollider2D component has been attached to each "wall" object. The speed can be changed via the "speed" variable.

    using UnityEngine;

    public class Bounce : MonoBehaviour
    {
        public float speed = 5f;
        private Rigidbody2D rb2d;
        private Vector3 lastVelocity;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
            rb2d.velocity = speed * new Vector2(1,1);
        }

        // Update is called once per frame
        void Update()
        {
            lastVelocity = rb2d.velocity;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb2d.velocity = direction * Mathf.Max(speed, 0f);
        }
    }
