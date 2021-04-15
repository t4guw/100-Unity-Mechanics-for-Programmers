# FPS Aim Assist

## Description
This mechanic shows how to implement an aim assist in a first person shooter game.

## Implementation
There are several steps that need to be done in the Unity Editor.
To view how to set up the character movement in 3D, refer to the [First Person Movement 3D](https://github.com/t4guw/100-Unity-Mechanics-for-Programmers/tree/master/programs/first_person_movement_3d) mechanic.

   1. Create a weapon and place it as a child of the main camera. (I used a handgun made by Nokobot on the [Unity Asset Store](https://assetstore.unity.com/packages/3d/props/guns/modern-guns-handgun-129821#description))
   2. Create the desired amount of enemies an set their tag to "Enemy".
   3. Set the enemy collider's size larger than the enemy itself to provide area for aim assist.
   4. Attach the AimAssist script to the weapon object.
