# Hunger Meter

## Description
This mechanic shows how to implement a hunger meter for the player. This implementation shows the meter decreases constantly and incrementally.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create an empty GameObject and attach a slider compenent to it with Interactable off, Transition set to None, Navigation set to None, and Direction to Top to Bottom.
   2. Create 2 UI Images as children of the previous GameObject. 
   3. Set both UI Images to the same image, one acts as the background and the other as the fill image.
   4. On the GameObject with the slider comenent, set the Fill Rect to the fill image child.
   5. Create prefabs for desired food items that can be collected (Edit the OnTriggerEnter2D function to accommodate the added food).