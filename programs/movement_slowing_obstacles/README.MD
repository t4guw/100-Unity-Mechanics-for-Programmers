# Movement Slowing Obstacles
## Description
This mechanic shows how to implement objects that modify the player's speed and gravity while colliding.

## Implementation
1. This implementation assumes you have accessable and editable player speed and jumpforce that's accessible via a component on the player object.
2. On the GameObject that you wish to have slowdown/speedup the player, make sure to have a RigidBody2D and have it set to static (unless you want it to move around). Also make sure to have it have a Collider 2D that has is Trigger checked.
3. The player also needs to have a RigidBody2D and Collider 2D.
4. Create a new script and have public float speedMod and public float gravityMod be the variables.
5. Create private void OnTriggerEnter2D(Collider2D other){} and OnTriggerExit2D(Collider2D other){}
6. Within the Enter method, get the Rigidbody2D component of "other" and multiply the gravityScale by the gravityMod:
other.GetComponent<Rigidbody2D>().gravityScale *= gravityMod;
7. Also get the PlayerMovement component (or whichever component you have for player movement) and multiply moveSpeed by speedMod and multiply jumpForce by speedMod.
8. Now all you have to do is in Exit is restore the player movement which you do by doing the same thing as step 6 and 7 but instead of MULTIPLYING you DIVIDE by the gravityMod and speedMod.
