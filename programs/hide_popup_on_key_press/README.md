# Show/Hide Map/Popup On Key Press

## Description
This mechanic demonstrates hiding or showing a popup on key press, however what is shown here can be used to show or hide any game object.

## Implementation
1. Create a new C# Script and name it "Popup".
2. In this case we have 2 Popups so we will make use of our Popup script twice on the Canvas (doesn't matter where you add our popup component as long as it is tied to the desired GameObject.)
3. Create a public KeyCode Object named "input"
4. Create a public GameObject named "popup"
5. Create a private bool named "activate" and have it equal to false (or true if you want to first show the object on key press rather than hide)
6. In the Update() Method, make an if statement that checks "Input.anyKey"
7. Within that if statement make an if statement to check "Input.GetKeyDown(input)" this checks only if the key was pressed down this update, so the popup doesn't show and hide rapidly while the key is pressed down
10. Within that if statement write "popup.SetActive(activate);"
11. After that line write activate = !activate; this will allow the script to renable/disable the object afterwards
12. Within Unity, under the Popup component of where you decided to attach it to, make sure you link the GameObject you want to show/hide and choose the key to activate.