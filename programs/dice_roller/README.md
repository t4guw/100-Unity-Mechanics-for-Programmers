# Dice Roller

## Description
This mechanic shows an implementation of rolling a die.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create the play area for the rolling of the die.
   2. Create or download a dice object and add it to the scene.
   3. Create a physics material with Friction set to 0 and Bounciness to 0.5.
   4. Add a Rigidbody, Box Collider, and Dice Behavior script to the dice object.
   5. On the Rigidbody, change Mass to 2 and Collision Detection to 'Continuous'.
   6. On the Box Collider, add the physics material to it.
   7. Create an empty GameObject, named "Side x", with a Sphere Collider 
   8. Set each "Side x" collider radius to 0.1 with a position 1 unit away from its corresponding side.
   9. Create another empty GameObject, named "Dice Checker", with a Box Collider and the Dice Check script attached.
   10. Move the "Dice Checker" right under the ground so that it can collide with the dice sides' collider.
   11. Set the "Dice Checker" collider's size to the size of the ground.
   

    