# Minimap in 2D

## Description
This mechanic shows how to implement a minimap in 2D, such as for a top-down view game and a 2D platformer.

## Implementation
The steps to implement this mechanic are done in the editor.
1. To add a minimap icon for each GameObject, add an empty GameObject as a child. Add a Sprite
Renderer component, and add a sprite to the Sprite field
2. Create a new minimap layer
3. Assign newly created minimap icons from step 1 to minimap layers
4. Deselect minimap layer from "Main Camera" culling mask, so to not render the minimap layer on top of everything
5. Create a new camera for the minimap, and select only the minimap layer for the culling mask
6. Add the minimap camera as a child of the "Main camera" to have it view the entire map, or attach it as a child of the player object to have the minimap follow the player
7. Set depth to 0 to be above the main camera
8. Create a new "Render Texture" in assets and increase size to a square (ex. 512x512, 256x256, etc.)
9. Go to the minimap camera in the hierarchy, and drap and drop the new render texture to the "Target Texture" property. This will make it so the camera is feeding its view to the render texture, rather than taking up the game screen.
10. Create a UI Canvas if one has not already been created
11. Create an empty GameObject in the canvas, and add "Raw Image" component
12. Add the texture to the newly added "Raw Image" component in the "Texture" field. This will take the minimap camera's feed and output it to the raw image.
13. Move the minimap created in step 11 in the scene to the desired location and set its size.
14. Go to the hierarchy and select the minimap camera, then set the background color to a color that
is non-transparent, such as a dark gray
15. To increase what is shown in the minimap, go to the hierarchy and select the minimap camera, then increase the size property in the inspector.

