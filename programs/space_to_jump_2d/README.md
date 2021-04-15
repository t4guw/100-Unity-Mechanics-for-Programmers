# Space Bar to Jump

## Description
This mechanic shows how to implement using the space bar to jump in a 2D Platformer game.

## Implementation
There are several steps that need to be done inside the Unity Editor to implement this mechanic.  

- Platform must have a Box Collider 2D component
- Player object must have Box Collider 2D and Rigidbody 2D components
- Gravity Scale of player object's Rigidbody2D component is greater than 0
- The platform/ground must be assigned to a layer  

The following code uses the space bar, a common button in many games, but can be replaced with any key. A boxcast is used to check if the player is grounded in order to prevent infinite jumping when in the air.

    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public bool grounded = true;
        private Rigidbody2D rb2d;
        public float jumpPower;
        private BoxCollider2D boxCollider2D;
        [SerializeField] private LayerMask platformsLayerMask;

        void Start()
        {
            rb2d = rb2d = GetComponent<Rigidbody2D> ();
            boxCollider2D = transform.GetComponent<BoxCollider2D>();
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) {
                rb2d.velocity = Vector2.up * jumpPower;
            }
        }

        private bool IsGrounded() {
            RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, platformsLayerMask);
            return raycastHit2D.collider != null;
        }
    }
