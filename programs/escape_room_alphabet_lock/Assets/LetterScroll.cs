using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterScroll : MonoBehaviour
{
    private string[] alphabetArray = new string[]{ "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };
    private TextMeshProUGUI letterText;
    private int currentLetter = 0;

    // Start is called before the first frame update
    void Start()
    {
        letterText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        letterText.text = alphabetArray[currentLetter];
    }

    public void increment()
    {
        if (currentLetter < 25) {
            currentLetter++;
        } else
        {
            currentLetter = 0;
        }
        letterText.text = alphabetArray[currentLetter];
    }

    public void decrement()
    {
        if (currentLetter > 0)
        {
            currentLetter--;
        }
        else
        {
            currentLetter = 25;
        }
        letterText.text = alphabetArray[currentLetter];
    }

    public string getLetter()
    {
        return alphabetArray[currentLetter];
    }

    public void setLetter(int letter)
    {
        currentLetter = letter;
        letterText.text = alphabetArray[currentLetter];
    }
}
