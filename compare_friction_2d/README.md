# Effects of Friction and Mass in 2D

## Description
This mechanic shows the effects of different coefficients of friction and objects' mass on movement in 2D.
By increasing mass and/or coefficients of friction, objects will accelerate slower and decelerate faster.
By decreasing mass and/or coefficients of friction, objects will accelerate faster and decelerate slower.
Space bar applies a constant, consistent force to all blocks. Keep in mind of the friction equation:
F = μN, where F is the Force of friction, μ is the friction coefficient, and N is the normal force.

## Implementation
This implementation shows 4 different blocks sliding on different terrain. It uses a common movement script for all block objects to keep force applied constant amongst all objects, and implements movement
using the space bar to initiate force to all blocks.

- Each block/player must possess both a Rigidbody 2D component and Box Collider 2D component
- Each terrain must possess a Box Collider 2D component
- To create different terrains with unique friction coefficients, create a new Physics 2D material
- To edit friction of the terrain, modify the "Friction" property of the Physics 2D material for the terrain. From the Unity Documentation, "Usually a value from 0 to 1. A value of zero feels like ice, a value of 1 will make it very hard to get the object moving."
- One way to increase frictional force is by increasing normal force. This can be done by increasing the mass of a block. This is done by editing the "Mass" property of the RigidBody 2D components of the blocks.
- The code/script below can be attached to all blocks/players and shows how to implement the space bar to apply the same force to all desired blocks.

##
    using UnityEngine;

    public class MovePlayer : MonoBehaviour {
        [SerializeField]private float acceleration = 10f;
        private Rigidbody2D rb2d;

        public Vector2 movement;

        void Start () {
            rb2d = GetComponent<Rigidbody2D> ();
        }


        void Update () {
            if (Input.GetKey(KeyCode.Space)) {
                moveCharacter(transform.right);
            } 
        }

        void moveCharacter(Vector3 direction) {
            rb2d.AddForce(direction * acceleration);
        }
    }