# QTE (Quick Time Event)

## Description
This mechanic will show how to implement the commmon QTE seen in many games.

## Implementation
There are several steps that need to be done in the Unity Editor.

   1. Create a gameobject prefab with a sprite renderer for each button included in the QTE.
   2. Attach the ButtonMovement script to each of the prefabs.
   2. Create an empty gameobject and place it as the Button Spawn Point.
   3. Create an empty gameobject to be the Game Manager.
   4. Attach the GameManager script to the Game Manager object.
   5. Put each button prefab in the Buttons array on the Game Mananger.

    