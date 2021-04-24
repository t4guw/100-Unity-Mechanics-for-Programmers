# Wheel Spinner

## Description
This mechanic shows how to implement wheel that the player can spin to earn a prize.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create a canvas and add the wheel to it.
   2. Create each section for the wheel as a child.
   3. Add Polygon Collider to each of the sections.
   4. Add a Text UI to each section as a child.
   5. Create a Triangle Sprite at the top of the wheel to indicate the selection.
   6. Add Polygon Collier to the triangle.
   7. Attach the WheelScript to the wheel object.
   8. Attach the SectionScript to each of the sections.
   9. Create a button to allow the user to spin the wheel.
   10. Put the SpinWheel() function in the OnClick() for the button.