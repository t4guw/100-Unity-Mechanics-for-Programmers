# Camera Panning

## Description
This mechanic shows how to implement camera panning. This can be used to make cutscences with dialouge. The camera will pan around one of the characters and then hold still for 3 seconds then swap to the other character and repeat.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create an empty GameObject as a Game Manager and attach the CameraPanningScript to it.
   2. Create a Player and NPC object.
   3. For both Player and NPC, create 2 empty GameObjects as children, 'Camera Viewpoint' and 'Camera Start'.
   4. Set both 'Camera Viewpoint' positions to (0,0,0).
   5. Adjust the Main Camera to the desired starting spot and copy it's transform values to the 'Camera Start' transform.
   6. Repeat step 5 for each character object.
   7. Set the Main Camera as the child of the 'Camera Viewpoint' for the desired starting character.