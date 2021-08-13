# Cookie Clicker
## Description
This mechanic shows how to implement the initial Cookie Clicker game with Auto Clickers, get ready for a ton of different ways to say click.

## Implementation
1. Create 4 C# Scripts: Clicker, Clicker Manager, Cookie, and Orbit
2. First the Orbit Script which will be the easiest one.
3. Create a public float speed variable.
4. Within Update() update the transform's Rotate with a new Vetctor3 of 0f, 0f, and Speed and multiply that Vector by deltaTime like so:
transform.Rotate(new Vector3(0f, 0f, speed) * Time.deltaTime);
Now, whatever has this script will rotate at the determined speed.
5. In Unity, create a new button called Cookie Button and give it a Cookie tag.
6. In Cookie Button, create an empty game object and name it Clicker Rotate, attach the orbit component to this object as this is what all clickers will be attached to and with thus rotate around the cookie.
7. While in Unity also create a ClickerSpawner Button.
8. Next is the Cookie script, add "using TMPro" to the using list.
9. Add private TextMeshProUGUI text and private int cookieCount = 0 to the variables.
10. Within start, assign text to the gameObject's TextMeshProUGUI component:
text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
11. Create a new method: public void ClickCookie(), when this is called by anyone, we know we need to update the cookie count and represent it in game.
12. Within ClickCookie create a string msg variable and set it equal to ""
13. Increase the cookieCount by 1 and add it to msg, lastly set text.text to msg.
14. Back in Unity, ad the Cookie Script to the Cookie Button and for the On Click() of the button, have it call the Cookie ClickCookie method. Now in game, the cookie count will increase by manual clicking.
15. Next is the Clicker Script, add using UnityEngine.UI to the using list at the top.
16. For variables add: 
    private float clickTime = 0.1f;
    private float clickTimer = 0f;
    private bool clicked = false;
    private GameObject cookie;
The clickTime and Timer is to simulate a slight dramatic mouse click where the release is delayed.
The bool clicked is for the Update to know if the clicker is in the middle of clicking.
And the cookie is for calling the ClickCookie method when our clicker clicks.
17. Within Start, assign cookie to the GameObject who's tag is Cookie (aka the Cookie Button)
18. Within Update, check to see if click is true, if it is, add Time.deltaTime to clickTimer, then check if clickTimer is greater than clickTime, if it is, call Unclick() and set clickTimer to 0.
19. Create a new method public void Click.
So one thing that I learned during this project is that it seems like there is no way to have a game component click a UI button so we have to just make it look like it's actually being clicked.
20. In Click, create a ColorBlock pressed and have it equal to cookie's Button component's colors:
ColorBlock pressed = cookie.GetComponent<Button>().colors;
21. Change the normalColor of pressed to .78 all rgb:
pressed.normalColor = new Color(.78f, .78f, .78f);
This makes the Cookie Button look clicked.
22. Next change the color of gameObject's SpriteRenderer component to a new Color to of .8f to all rgb:
gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f);
This darkens the clicker to identify it is the one clicking
23. Set cookie's Button component colors to the updated pressed ColorBlock and set clicked to true.
24. Create a public void Unclick method and here we do the same thing in click but set the colors back to 1f:
        ColorBlock unpressed = cookie.GetComponent<Button>().colors;
        unpressed.normalColor = new Color(1f,1f,1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        cookie.GetComponent<Button>().colors = unpressed;
        clicked = false;
25. Create a prefab in Unity of your clicker object with the Clicker component attached.
26. Lastly is the ClickerManager script, add usingUnityEngine.UI to the using list.
27. For Variables:
    public GameObject clickerObj;
    private List<GameObject> clickerList;
    private int clickerCount = 0;
    public float clickerInterval = 2f;
    private double numberInterval;
    private double clickerTimer = 0;
    private int clickerClick = 0;
    private Cookie cookie;
The public GameObject clickerObj is the prefab we're going to spawn whenever we click the Spawn Clicker button
The List is for keeping track of our clickers and so we can update them whenever a new one gets added.
clickerCount so we know offhand how many clickers there are.
clickerInterval is how often a clicker clicks
numberInterval is the real frequency of clicker clicks as if you have 2 clickers, the button is getting clicked once per second and so on.
clickerTimer is for timing between clicks.
clickerClick is to keep track of which clickers have clicked so we can pick a new clicker
and cookie so we can update the number.
28. Within the Start method assign cookie to the Parent Object's component Cookie:
cookie = gameObject.GetComponentInParent<Cookie>();
29. Initialize the clickerList by assigning it as a new GameObject List.
30. And call SpawnClicker() so we have one clicker at the start of the game.
31. Within Update add Time.deltaTime to clickerTimer and check if clickerTimer is >= to numberInterval, if it is then call ClickClicker() and set clickerTimer to 0
32. Create private void ClickClicker()
33. Within ClickClicker call cookie's ClickCookie method
34. Call clickerList[clickerClick]'s Clicker component's Click method and increment clickerClick
35. Check to see if clickerClick has reached the clickerList's size, if it has, set it back to 0.
36. Create a public void SpawnClicker() method
37. Within SpawnClicker increment clickerCount, update numberInterval to be equal to clickerInterval divided by clickerCount
38. Create a new GameObject newClicker as an Instantiated clickerObj
39. Assign the newClicker's name to Clicker + clickerCount (this just makes the Unity Hierarchy look nicer rather than Clicker(Clone) everywhere)
40. Assign the newCicker's transform parent to transform (this places the clicker as a child to whoever has this script)
41. Update the newClicker's transform position as new Vector3(0f, -1.8f, 0); (In our case the radius of the cookie is approximatedly 1.8)
42. Add newClicker to the clickerList and call RepositionClickers();
43. Create private void RepositionClickers()
44. Create a float theta and have it equal (2*Mathf.PI) / clickerCount; this determines our theta for determining the circle coordinates for each clicker.
45. Make a for loop that goes while less than clickerList's length.
46. Within this loop update clickerList[i]'s transform position to a new Vector3Vector3(1.8f * Mathf.Cos(theta*i), 1.8f * Mathf.Sin(theta * i));
47. Next we update the rotation of the clicker so it's still pointing at the center of the cookie by creating a new Vector3 direction that's equal to transform.position - clickerList[i].transform.position;
48. Assign clickerList[i].transform.up to direction.
49. Back in Unity, add the ClickerManager component to the Clicker Rotate object under the Cookie Button.
50. Update the ClickerSpawner so it's On Click() calls Clicker Rotate's ClickerManager's SpawnClicker method.
51. And that should do it, starting the game a clicker should spawn and slowly orbit the cookie, clicking it every 2 seconds (if you set that as it's interval). You can add more and see the clickers reposition so they're equally apart from another.