using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordSystem : MonoBehaviour
{
    public GameObject Letter1;
    public GameObject Letter2;
    public GameObject Letter3;
    public GameObject Letter4;
    public GameObject Letter5;
    public GameObject Letter6;
    public GameObject Letter7;
    public GameObject Text;
    public GameObject Correct;
    public GameObject Wrong;

    private string[] alphabetArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    System.Random r = new System.Random();

    private string password = "";

    // Start is called before the first frame update
    void Start()
    {
        // Set up password
        int rInt;
        for (int i = 0; i < 7; i++) { 
            rInt = r.Next(0, 25);
            password += alphabetArray[rInt];
        }

        // Update StickyNote
        Text.GetComponent<TextMeshProUGUI>().text = password;
    }


    public void confirm()
    {
        string userAttempt = "";
        userAttempt += Letter1.GetComponent<LetterScroll>().getLetter();
        userAttempt += Letter2.GetComponent<LetterScroll>().getLetter();
        userAttempt += Letter3.GetComponent<LetterScroll>().getLetter();
        userAttempt += Letter4.GetComponent<LetterScroll>().getLetter();
        userAttempt += Letter5.GetComponent<LetterScroll>().getLetter();
        userAttempt += Letter6.GetComponent<LetterScroll>().getLetter();
        userAttempt += Letter7.GetComponent<LetterScroll>().getLetter();

        if (password.Equals(userAttempt))
        {
            Correct.GetComponent<Image>().color = new Color(1f,1f,1f);
            Wrong.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
            // Call Method Here for your Game to Progress
        } else {
            Correct.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
            Wrong.GetComponent<Image>().color = new Color(1f, 1f, 1f);
        }
    }

    public void Reset()
    {
        Letter1.GetComponent<LetterScroll>().setLetter(0);
        Letter2.GetComponent<LetterScroll>().setLetter(0);
        Letter3.GetComponent<LetterScroll>().setLetter(0);
        Letter4.GetComponent<LetterScroll>().setLetter(0);
        Letter5.GetComponent<LetterScroll>().setLetter(0);
        Letter6.GetComponent<LetterScroll>().setLetter(0);
        Letter7.GetComponent<LetterScroll>().setLetter(0);
    }
}
