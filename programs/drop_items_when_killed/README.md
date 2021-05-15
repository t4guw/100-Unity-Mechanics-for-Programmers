# Drop Items When Killed

## Description
This mechanic shows how to implement players' items falling on the ground when they are killed.

## Implementation
To set up the inventory system, check out [Pick Up Object When Character Walks Over in 2D](https://github.com/t4guw/100-Unity-Mechanics-for-Programmers/tree/master/programs/pick_up_object_when_character_walks_over_2d).
There are several steps that need to be taken in the Unity Editor.

   1. Create a cube and make it act as the ground.
   2. Attach a Box Collider 2D and Rigidbody 2D to the ground.
   3. Change the Rigidbody 2D to Body Type - Static.
   4. Attach the ItemInteraction script to the Player object.
    
 

