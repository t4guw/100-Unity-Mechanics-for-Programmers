# Sleep to Skip Time

## Description
This mechanic shows how to implement a sleeping mechanic that allows the player skip forward to a desired time.

## Implementation
There are several steps that need to be taken in the Unity Editor.
To view how to set up the character movement in 3D, refer to the [First Person Movement 3D](https://github.com/t4guw/100-Unity-Mechanics-for-Programmers/tree/master/programs/first_person_movement_3d) mechanic.

   1. Create a bed object and attach a Rigidbody and Box Collider to it.
   2. Create the UI to prompt the user to sleep.
   3. Create 2 dropdowns, one for the hours and one for AM or PM.
   4. Create an empty gameobject, 'Dropdowns', as a parent to the dropdowns.
   5. Set the prompt sleep UI and 'Dropdowns' to inactive.
   6. Attach the SleepScript to the Bed.
   7. Create a text UI to display the current in-game time.
   8. Attach the ClockScript to the Time text.
   9. Drag the corresponding gameobjects to the public variables in the SleepScript and ClockScript.