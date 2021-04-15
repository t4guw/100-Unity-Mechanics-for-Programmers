# Cell Phone

## Description
This mechanic shows how to implement an in-game cell phone with interactble apps.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create or find an image to use as the phone and put it in a canvas UI image.
   2. Attach the Phone script and App Interaction script to the phone object. (Everything created should be made as a child of the phone object)
   3. Place the phone just below the bottom right of the screen.
   4. Create a text UI for the phone's clock.
   5. Create UI Button over the phone's home button, make it transparent and delete the button text.
   6. Set it's OnClick() to HomeButton() from the phone's App Interaction script.
   7. Create two empty objects and name them "Home Screen" and "In Apps".
   8. For each app desired, create a UI Button as the child of "Home Screen" for each and name it accordingly.
   9. Attach the App Icon script to each app created and set the source image to indicate what the app is.
   10. Add a box collider to each app the size of the icon.
   11. Create empty objects for each app and put them as children of the "In Apps" object.
   12. Create the desired look/functions for each app as children of it's given parent.
   13. Create a text UI to dislay the app name that is either selceted or being hovered over.
   14. Put the child of "In Apps" in the Apps array in the phone object's App Interaction script.
   15. Set the OnClick() of each "Home Screen" child to OpenApp() from the phone's App Interaction script with the index you gave it in the previous array.

    
  
    
    
