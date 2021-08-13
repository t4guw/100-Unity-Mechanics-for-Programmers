# Escape Room Alphabet Lock
## Description
This mechanic shows how to implement a simple alphabet lock.

## Implementation
1. In this implementation we have a few custom images for assets, those being, the green triangle, green check, red x, and a stickynote image found online. These aren't required but some of them help indicate usage.
2. Create a Panel, name it LetterWindow
3. In LetterWindow create two new buttons; Decrement and Increment, place decrement above and increment below the LetterWindow in the Scene (not Hierarchy, the Scene)
4. In LetterWindow create a Text object and set the text to A
5. Now create a new C# Script called LetterScroll
6. Within LetterScroll, add "using UnityEngine.UI" (and if you're also using TextMeshPro; "using TMPro")
7. For variables: 
private string[] alphabetArray = new string[]{ "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z" };
private TextMeshProUGUI letterText; (Replace TextMeshProUGUI with Text if you're using regular Text)
private int currentLetter = 0;
8. Within Start(), lets grab the gameObject's TextMeshProUGUI component and make sure it's updated to the first letter in the array:
letterText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
letterText.text = alphabetArray[currentLetter];
9. Next create public void increment() and public void decrement()
10. For increment() we want to increment currentLetter unless it's already at 25, if it is, set it to 0 then update the text:
if (currentLetter < 25) {
            currentLetter++;
        } else
        {
            currentLetter = 0;
        }
        letterText.text = alphabetArray[currentLetter];
11. Do the same thing for decrement but in this case check if currentLetter is already at 0, if it is, set it to 25 then update text:
if (currentLetter > 0)
        {
            currentLetter--;
        }
        else
        {
            currentLetter = 25;
        }
        letterText.text = alphabetArray[currentLetter];
12. Next create a public string getLetter() that returns the letter the text is set to:
return alphabetArray[currentLetter];
13. Next create a public void setLetter(int letter) that sets the currentLetter to the sent integer and updates the text.
14. In Unity, add LetterScroll to LetterWindow
15. For the Decrement button in LetterWindow, have it's on click function be LetterScroll.decrement and for the Increment Button, LetterScroll.increment
16. You can test the scene and see that now the box will cycle through letters as you click the buttons.
17. Copy LetterWindow as many times as you want the password to be long and make sure to name them appropriately, in this case we used 7 so they're called LetterWindow1-7
18. Next create another C# script called "PasswordSystem"
19. In PasswordSystem add "using UnityEngine.UI" (and if you're also using TextMeshPro; "using TMPro")
20. For variables, create a public GameObject Letter1-X for as many LetterWindows you ended up using.
21. In our case we show the user the current password as well as have a checkmark object when they get it right and a x when they get it wrong so we have 3 more public GameObject's, Text, Correct, and Wrong
22. Also the same alphabetArray as in LetterScroll and create a System.Random r = new System.Random(); (make sure to do System. as Unity has it's own different Random object) and create a private string password that's equal to ""
23. Within Start() initialize int rInt and create a for loop that loops the number of LetterWindow objects you made as that will be the password length, within that loop, have rInt equal r.Next(0, 25) and add alphabetArray[rInt] to password. This sets up the password that we will check when the user clicks confirm.
24. As stated before, in our case we tell the user the password so we update the text containing it after the loop: Text.GetComponent<TextMeshProUGUI>().text = password;
25. Create public void confirm()
25. Inside confirm, make a scrint variable called userAttempt and have it equal ""
26. Now add each letter from each LetterWindow using getLetter() to userAttempt like so: 
userAttempt += Letter1.GetComponent<LetterScroll>().getLetter();
27. Now create an if else that checks password.Equals(userAttempt)
28. for the if, we highlight the checkmark image and dim the x image:
Correct.GetComponent<Image>().color = new Color(1f,1f,1f);
Wrong.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
This is also where you'd want to call a method or something that would progress the game.
29. For the else, we just do the opposite:
Correct.GetComponent<Image>().color = new Color(1f,1f,1f);
Wrong.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
30. Lastly make a public void Reset() that resets each letter in each letter window:
Letter1.GetComponent<LetterScroll>().setLetter(0);
31. Back in Unity, add the PasswordSystem to EventSystem (it doesn't have to be EventSystem but it just makes sense). Make sure to assign each LetterWindow in order as well as the password text, the correct image, and incorrect image.
32. Create a Confirm Button and a Reset Button, as well as a Correct and Wrong image if you want to highlight them based on if the user inputs the right password.
33. For the Confirm's on click, have it call EventSystem's PasswordSystem.confirm
34. For the Reset's on click, have it call EventSystem's PasswordSystem.reset
35. Everything should be set up so feel free to try it in Unity!