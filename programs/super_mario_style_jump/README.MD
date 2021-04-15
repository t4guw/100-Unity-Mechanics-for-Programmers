# Super Mario Style Jump
## Description
This mechanic shows how to implement jumping like in Super Mario Bros (holding jump allows you to jump to the fullest height, tapping gives you a short jump, and running before jumping gives you a higher jump)

## Implementation
1. This mechanic relies on your PlayerMovement script which you may have to change around to accomodate this implementation.
2. Within your PlayerMovement script, create a public float jumpForce, jumpDelay, and runningJumpForce and set these to 15f, 0.25f, and 5f respectively.
jumpForce is self explainatory but jumpDelay allows a window for the player to press jump while they're about to land so they don't have to do a frame perfect jump press to immediately jump again.) Lastly, runningJumpForce is the extra force applied to a jump based on how fast the player is moving.
3. (This assumes you haven't seen the other Jump Mechanics) also create a public LayerMask groundLayer, a public float groundLength, a public float linearDrag = 4f, a public float gravity = 1, a public float fallMultiplier = 5f, and a public Vector3 colliderOffset.
We'll be using a raycast to detect when the player is allowed to jump and it will only be detecting collisions with our Ground Layer, linearDrag in our case is used to apply drag on the player during certain parts of jumps and movement.
4. Lastly create a private bool onGround, a private Rigidbody2D rb (ignore if you already have this), and a private float jumpTimer
5. On void Awake make sure you grab the RigidBody2D component on this gameObject and assign it to rb.
6. In void Update have onGround equal to:
Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);
This draws two raycasts based on your colliderOffset (something to fine tune within Unity, at the end we'll be visually drawing them for Gizmos so you know where you're putting them) to tell if the player is on the ground or not. You will also need to fine tune groundLength so it is just slightly longer than the player's collider as it won't work if it is not.
7. Next write an if statement that checks for the "Jump" input on GetButtonDown, within this statement set jumpTimer to Time.time + jumpDelay.
8. Within void FixedUpdate write an if statment to check if jumpTimer is greater than Time.time AND onGround is true, within this if statement call Jump().
9. Outside of that if statement call ModifyPhysics().
10. Create a private void ModifyPhysics() method
11. Within ModifyPhysics create an if statement that checks !onGround (This deviates slightly from the project as the original if statement is mainly for horizontal movement but in this case we're just doing the jump physics).
12. Within that if statement set rb.gravityScale to gravity, rb.drag to linearDrag * 0.15f (you can fine tune the 0.15 for your preference)
13. Create another if statement within this one that checks if rb.velocity.y is less than 0, within this statement set rb.gravityScale to gravity * fallMultiplier
14. Create an else if for that if statement that checks if rb.velocity.y is greater than 0 AND that "Jump" input is not being pressed. Within this set rb.gravityScale to gravity * (fallMultiplier/2)
15. Now create an else for the main if statement (the one that checks !onGround) and have ot set rb.drag to 0 and rb.gravityScale to 0.
What all of this does is: When the player jumps and is holding down the jump button, the gravity scale is reduced to achieve a higher jump like in Mario, the moment the jump button is released or the player starts falling, the gravity scale increases to pull the player back down.
16. Now create a private void Jump() method.
17. Create a float runJump that is equal to: (Mathf.Abs(rb.velocity.x) / maxSpeed) * runningJumpForce
This calculates the extra jump boost from running, we get a percentage of the current speed based on the maxSpeed (if you don't have a maxSpeed variable you will need one), and multiply it to the runningJumpForce. So like in Mario if you achieve the fastest running speed, you can get the highest jump.
18. Set rb.velocity to a new Vector2 that takes in rb.velocity.x and 0
19. Now call rb's AddForce: rb.AddForce(Vector2.up * (jumpForce + runJump), ForceMode2D.Impulse)
20. Then set jumpTimer back to 0.
21. Lastly create private boid OnDrawGizmos() (make sure it's written exactly like this as this is a method called by unity)
22. Within OnDrawrGizmos set Gizmos.color to Color.red (or whatever you prefer)
23. Call Gizmos.DrawLine similarly to how we drew those raycasts:
Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);

Now when running the game and having Gizmos on, you can see the raycasts we are drawing for the onGround bool, increase the x value of colliderOffset in Unity to increase the distance between the two raycasts, they should be just slightly within the bounds of your collider (otherwise walls could set off the onGround bool).

Now your jumping should be complete, if you encounter any issues you may want to consider implementing the horizontal movement within the PlayerMovement script in the sourcecode as well as they go a bit hand in hand with the code.
