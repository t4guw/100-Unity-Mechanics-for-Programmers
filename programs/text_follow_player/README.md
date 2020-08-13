# Text Follow Player 2D & Hide/Show UI

## Description
This mechanic shows how to make text follow a player, as well as hiding and showing a UI element on key press.
This is helpful if you want, for example, a player's name to always be above their head. Hiding and showing a UI element could
be helpful when trying to show a map on key press.

## Implementation
To make text follow a player, the steps are done in the Unity Editor. 
1. Under the player object, create a new Canvas as a child, and in that canvas, create a Text element. 
2. Set the Canvas render mode to "World Space."
3. Anchor the text to the top middle, or any other desired spot.

To hide and show a UI element on keypress, add the following simple script to the element you want to hide/show:

        using UnityEngine;
        using UnityEngine.UI;

        public class Show_Hide : MonoBehaviour
        {
        
            void Update()
            {
                if (Input.GetKeyDown(KeyCode.M))
                {
                    this.GetComponent<Image>().enabled = !this.GetComponent<Image>().enabled;
                }
            }
        }
