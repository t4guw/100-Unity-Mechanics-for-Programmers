# Scrollable UI Elements
## Description
This mechanic shows how to have a UI Element with content you can scroll around with

## Implementation
1. Have a Canvas and Panel Created, the Panel will be the UI Element that contains the information.
2. Within that Panel, create another Panel called Container, this will be the scrollable content.
3. Within Container you can put any Information you want for the player to be able to view.
4. Within the Original Panel, add a Mask Component, this will hide anything within the Panel that is outside itself.
5. Within the Original Panel, add a Scroll Rect Component, for Content, select the Container, you can check/uncheck vertical or horizontal based on how you want the ui to be scrollable.
6. Within the Original Panel, add a Scrollbar UI Object, you can determin the default direction of the handle such as Top To Bottom
7. Add another if you want to do vertical and horizontal, name them appropriately.
8. Back on the Original Panel's Scroll Rect Component, add your scroll bars to the appropriate places (Horizontal Scroll Bar and Vertical Scroll Bar).
9. This is all that is needed to set up the scrollable elements. Scroll Rect can be very tempermental and determines the size of the handles of the scroll bars dynamically with the size of the content.
The content within the Container panel seems to decide the scrollability of the scrollbars (you can still drag around the UI within the container without the scroll bars)