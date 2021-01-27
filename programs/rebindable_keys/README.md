# Rebindable Keys
## Description
This mechanic shows how to implement rebindable keys using Input

## Implementation
1. Create a new script called "KeyPress"
2. In this case, we have our rebind ability within the same script that does the action upon key press, we also use a button to allow rebinding.
3. Include "using UnityEngine.UI;" at the top of the script
4. Have these as variables:
public KeyCode input;
private Text text;
private bool newKey = false;
5. These are for the user input key, the button's text that will update to tell the user which key does the action, and a bool for checking for new key input respectively.
6. In our script we have a custom "On Button Press()" action for our action, if you would like to do this to: 
add using UnityEngine.Events;
add anywhere in your class:
[System.Serializable]
public class InteractionEvent : UnityEvent { }

public InteractionEvent onInteraction = new InteractionEvent();

public void Interact()
{
    onInteraction.Invoke();
}
7. In Start() add "text = gameObject.GetComponentInChildren<Text>();" to grab the button's text object
8. In Update() add:
	if(Input.anyKeyDown && newKey)
        {
            text.text = WhichKey();
            newKey = false;
        }
        else if (Input.GetKeyDown(input))
        {
            Interact();
        }
This does two things, 1: when we are waiting for a new key to update the bind (we will be writing WhichKey() later), we check if a key is pressed and if newKey is true. 2. Call the interaction to be done on key press.
9. Create public void WaitingForKeyPress(){
        text.text = "Waiting for key press...";
        newKey = true;
    }
This sets up the update method to know that we are attempting to rebind the key and updates the button's text to let the user know.
10. Now create public string WhichKey()
The Input library doesn't actually have a function for grabbing the specific key that is being pressed in any way so in order to find out which key is pressed we have to do a huge if/else list.
11. Within WhichKey() paste this monstrosity:
	// Letters
        if (Input.GetKey(KeyCode.A)) { input = KeyCode.A; return "A"; }
        else if (Input.GetKey(KeyCode.B)) { input = KeyCode.B; return "B"; }
        else if (Input.GetKey(KeyCode.C)) { input = KeyCode.C; return "C"; }
        else if (Input.GetKey(KeyCode.D)) { input = KeyCode.D; return "D"; }
        else if (Input.GetKey(KeyCode.E)) { input = KeyCode.E; return "E"; }
        else if (Input.GetKey(KeyCode.F)) { input = KeyCode.F; return "F"; }
        else if (Input.GetKey(KeyCode.G)) { input = KeyCode.G; return "G"; }
        else if (Input.GetKey(KeyCode.H)) { input = KeyCode.H; return "H"; }
        else if (Input.GetKey(KeyCode.I)) { input = KeyCode.I; return "I"; }
        else if (Input.GetKey(KeyCode.J)) { input = KeyCode.J; return "J"; }
        else if (Input.GetKey(KeyCode.K)) { input = KeyCode.K; return "K"; }
        else if (Input.GetKey(KeyCode.L)) { input = KeyCode.L; return "L"; }
        else if (Input.GetKey(KeyCode.M)) { input = KeyCode.M; return "M"; }
        else if (Input.GetKey(KeyCode.N)) { input = KeyCode.N; return "N"; }
        else if (Input.GetKey(KeyCode.O)) { input = KeyCode.O; return "O"; }
        else if (Input.GetKey(KeyCode.P)) { input = KeyCode.P; return "P"; }
        else if (Input.GetKey(KeyCode.Q)) { input = KeyCode.Q; return "Q"; }
        else if (Input.GetKey(KeyCode.R)) { input = KeyCode.R; return "R"; }
        else if (Input.GetKey(KeyCode.S)) { input = KeyCode.S; return "S"; }
        else if (Input.GetKey(KeyCode.T)) { input = KeyCode.T; return "T"; }
        else if (Input.GetKey(KeyCode.U)) { input = KeyCode.U; return "U"; }
        else if (Input.GetKey(KeyCode.V)) { input = KeyCode.V; return "V"; }
        else if (Input.GetKey(KeyCode.W)) { input = KeyCode.W; return "W"; }
        else if (Input.GetKey(KeyCode.X)) { input = KeyCode.X; return "X"; }
        else if (Input.GetKey(KeyCode.Y)) { input = KeyCode.Y; return "Y"; }
        else if (Input.GetKey(KeyCode.Z)) { input = KeyCode.Z; return "Z"; }
        // Numbers
        else if (Input.GetKey(KeyCode.Alpha0)) { input = KeyCode.Alpha0; return "0"; }
        else if (Input.GetKey(KeyCode.Alpha1)) { input = KeyCode.Alpha1; return "1"; }
        else if (Input.GetKey(KeyCode.Alpha2)) { input = KeyCode.Alpha2; return "2"; }
        else if (Input.GetKey(KeyCode.Alpha3)) { input = KeyCode.Alpha3; return "3"; }
        else if (Input.GetKey(KeyCode.Alpha4)) { input = KeyCode.Alpha4; return "4"; }
        else if (Input.GetKey(KeyCode.Alpha5)) { input = KeyCode.Alpha5; return "5"; }
        else if (Input.GetKey(KeyCode.Alpha6)) { input = KeyCode.Alpha6; return "6"; }
        else if (Input.GetKey(KeyCode.Alpha7)) { input = KeyCode.Alpha7; return "7"; }
        else if (Input.GetKey(KeyCode.Alpha8)) { input = KeyCode.Alpha8; return "8"; }
        else if (Input.GetKey(KeyCode.Alpha9)) { input = KeyCode.Alpha9; return "9"; }

        // KeyPad
        else if (Input.GetKey(KeyCode.Keypad0)) { input = KeyCode.Keypad0; return "Keypad 0"; }
        else if (Input.GetKey(KeyCode.Keypad1)) { input = KeyCode.Keypad1; return "Keypad 1"; }
        else if (Input.GetKey(KeyCode.Keypad2)) { input = KeyCode.Keypad2; return "Keypad 2"; }
        else if (Input.GetKey(KeyCode.Keypad3)) { input = KeyCode.Keypad3; return "Keypad 3"; }
        else if (Input.GetKey(KeyCode.Keypad4)) { input = KeyCode.Keypad4; return "Keypad 4"; }
        else if (Input.GetKey(KeyCode.Keypad5)) { input = KeyCode.Keypad5; return "Keypad 5"; }
        else if (Input.GetKey(KeyCode.Keypad6)) { input = KeyCode.Keypad6; return "Keypad 6"; }
        else if (Input.GetKey(KeyCode.Keypad7)) { input = KeyCode.Keypad7; return "Keypad 7"; }
        else if (Input.GetKey(KeyCode.Keypad8)) { input = KeyCode.Keypad8; return "Keypad 8"; }
        else if (Input.GetKey(KeyCode.Keypad9)) { input = KeyCode.Keypad9; return "Keypad 9"; }
        else if (Input.GetKey(KeyCode.KeypadPeriod)) { input = KeyCode.KeypadPeriod; return "Keypad ."; }
        else if (Input.GetKey(KeyCode.KeypadEquals)) { input = KeyCode.KeypadEquals; return "Keypad ="; }
        else if (Input.GetKey(KeyCode.KeypadEnter)) { input = KeyCode.KeypadEnter; return "Keypad Enter"; }
        else if (Input.GetKey(KeyCode.KeypadMinus)) { input = KeyCode.KeypadMinus; return "Keypad -"; }
        else if (Input.GetKey(KeyCode.KeypadDivide)) { input = KeyCode.KeypadDivide; return "Keypad /"; }
        else if (Input.GetKey(KeyCode.KeypadPlus)) { input = KeyCode.KeypadPlus; return "Keypad +"; }
        else if (Input.GetKey(KeyCode.KeypadMultiply)) { input = KeyCode.KeypadMultiply; return "Keypad *"; }

        // Misc
        else if (Input.GetKey(KeyCode.Space)) { input = KeyCode.Space; return "Space"; }
        else if (Input.GetKey(KeyCode.LeftAlt)) { input = KeyCode.LeftAlt; return "Left Alt"; }
        else if (Input.GetKey(KeyCode.RightAlt)) { input = KeyCode.RightAlt; return "Right Alt"; }
        else if (Input.GetKey(KeyCode.LeftControl)) { input = KeyCode.LeftControl; return "Left Ctrl"; }
        else if (Input.GetKey(KeyCode.RightControl)) { input = KeyCode.RightControl; return "Right Ctrl"; }
        else if (Input.GetKey(KeyCode.Escape)) { input = KeyCode.Escape; return "Escape"; }
        else if (Input.GetKey(KeyCode.Return)) { input = KeyCode.Return; return "Enter"; }
        else if (Input.GetKey(KeyCode.Backspace)) { input = KeyCode.Backspace; return "Backspace"; }
        else if (Input.GetKey(KeyCode.Backslash)) { input = KeyCode.Backslash; return "\\"; }
        else if (Input.GetKey(KeyCode.Colon)) { input = KeyCode.Semicolon; return ";"; }
        else if (Input.GetKey(KeyCode.Period)) { input = KeyCode.Period; return "."; }
        else if (Input.GetKey(KeyCode.Comma)) { input = KeyCode.Comma; return ","; }
        else if (Input.GetKey(KeyCode.LeftBracket)) { input = KeyCode.LeftBracket; return "["; }
        else if (Input.GetKey(KeyCode.RightBracket)) { input = KeyCode.RightBracket; return "]"; }
        else if (Input.GetKey(KeyCode.Equals)) { input = KeyCode.Equals; return "="; }
        else if (Input.GetKey(KeyCode.Slash)) { input = KeyCode.Slash; return "/"; }
        else if (Input.GetKey(KeyCode.Minus)) { input = KeyCode.Minus; return "-"; }
        else if (Input.GetKey(KeyCode.UpArrow)) { input = KeyCode.UpArrow; return "Up Arrow"; }
        else if (Input.GetKey(KeyCode.DownArrow)) { input = KeyCode.DownArrow; return "Down Arrow"; }
        else if (Input.GetKey(KeyCode.LeftArrow)) { input = KeyCode.LeftArrow; return "Left Arrow"; }
        else if (Input.GetKey(KeyCode.RightArrow)) { input = KeyCode.RightArrow; return "Right Arrow"; }
        else { print("No valid key was pressed!"); return text.text; }
12. This accounts for most keys except for F keys, Lock keys, Insert, Home, Page Up, Page Down, Delete, and End keys, (and any other unusual keys such as FN)
13. It is also difficult to convert a KeyCode into a String to update the button text so here we also return the key as a string.
14. Back in Unity, attach this script to the button that will change the keybind.
15. For OnClick() drag the Button object and in the dropdown navigate KeyPress>WaitingForKeyPress
16. For the Key Press script, this does whatever you need it to do (such as Jump, shoot, etc).
17. This does have an issue where if the user presses one button, then another without first pressing a key to rebind, they will need to click the first button again if they want to rebind the key (text will not update until this happens)