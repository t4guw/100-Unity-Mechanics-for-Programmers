# Upgrade Shop
## Description
This mechanic shows how to set up a basic Upgrade Shop

## Implementation
In this mechanic we assume you have a weapons script that have a lock/unlock system (In this project this is done simply by having a bool checked before the weapon can be fired.

In your weapons system script, make sure you have public void methods for enabling specific weapons, this can be done in separate scripts but that's not shown in this example.

1. After that everything can be done within Unity, create a panel game object, this will automatically also create a canvas object for it to go into.
2. The panel will be the upgrade menu, you can change it's image, color, etc to suite your game. Within the panel, create as many buttons as you have upgrades (ie Button for Speed Boost, Button for New Weapon, etc)
3. Set the button up to look and function to your tastes, for "On Click()" add a function, drag the game object that has your weapon system script in it.
4. Via the dropdown menu find your script and your unlock method.
5. Repeat this for the other buttons for any other unlocks.
6. As stated before, in this project our weapons are locked via simple booleans, so our public void unlock methods simply flip this boolean.
7. Disable the Panel game object, we only want to bring it up when the player wants to access it. This can be done through many systems.
8. In our case we simply have a button press to enable/disable it, create a Popup script and add it to the Canvas (This is the same script for show/hide popups mechanic)
9. For variables write: 
    public GameObject popup;
    public KeyCode input;
    private bool activate = false;
10. Under Update() write:
if (Input.anyKey)
        {
            if (Input.GetKeyDown(input))
            {
                popup.SetActive(activate);
                activate = !activate;
            }
        }
11. In unity make sure you have the panel assigned as the popup in the script under canvas.