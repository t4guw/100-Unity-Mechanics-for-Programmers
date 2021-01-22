using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    public Text number;
    int numberLength = 0;
  
    public void KeyPushed(int num)
    {
        if (numberLength <= 6)
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
