# Number Keypad

## Description
This mechanic shows how to implement a number keypad.

## Implementation
Several steps need to be taken in the Unity Editor.

   1. Create a canvas.
   2. Create or find a free keypad image without buttons and put that in the canvas.
   3. Add 12 buttons to the canvas for 0-9, 'CLR', and 'OK' buttons.
   4. Arrange the buttons onto the empty keypad.
   5. Set the image on each button to an image of the correct number or word.
   6. Attach the Keypad script below to the Keypad gameobject.
   7. For buttons 0-9, set the OnClick() to call KeyPushed with the num variable being the button number.
   8. Set the OnClick() for the 'CLR' and 'OK' buttons to ClrPushed() and OkPushed(), respectively.
   9. Create a UI Text to put over the keypad screen and pass it into the Keypad script as the global variable number.
    
    using UnityEngine;
    using UnityEngine.UI;

    public class Keypad : MonoBehaviour
    {
        public Text number;
        int numberLength = 0;
  
        public void KeyPushed(int num)
        {
            if (numberLength < 6)
            {
                number.text += (num + "");
                numberLength++;
            }
        }

        public void ClrPushed()
        {
            number.text = "";
            numberLength = 0;
        }

        // Put your own pass/fail case here
        public void OkPushed()
        {
            number.text = "Approved";
        }
    }
