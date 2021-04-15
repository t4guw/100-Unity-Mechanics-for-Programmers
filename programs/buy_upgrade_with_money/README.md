# Buy Upgrade With Money
## Description
This mechanic shows how to purchase upgrades with money using the previously made Upgrade Shop

## Implementation
This implementation assumes you are using textmeshpro, however the changes to make if you are not are minor.
1. Create a new script called Money and attach it to the Player.
2. For variables write:
    public int startingMoney = 500;
    private int currentMoney;
    public GameObject moneyCounter;
    private TextMeshProUGUI textMesh;
3. You can set the default starting money to anything, the private current money is for the script, it will be accessible via methods for other objects. The money counter object is the tmp object we want to update (if you have one)
4. Within the start method write: 
    currentMoney = startingMoney;
    textMesh = moneyCounter.GetComponent<TextMeshProUGUI>();
5. At the start of the game we set the current money to the desired starting money, we also grab the UGUI component of the text mesh pro object
6. Within the update method write:
    textMesh.text = currentMoney.ToString();
7. This simply updates the money counter text to the current money the player has.
8. Create an addFunds(int newFunds) method that adds newFunds to currentMoney
9. Create an deductFunds(int cost) method that deducts the cost to currentMoney
10. Create an int currentFunds() method that returns currentMoney;
11. Now create a new script called ButtonCost and put it on any buttons you will be using to purchase upgrades.
12. For variables write:
    public GameObject player;
    public int cost;
13. player is the player object (or rather any object that has the Money script) and public int cost is the cost of the upgrade for that button.
14. within the Update method write:
if (player.GetComponent<Money>().currentFunds() < cost)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
15. This dynamically disables the button if the player does not have enough money to purchase the upgrade.
16. In unity and on the button(s) make sure you add another On Click() function tied to the player (or object) that has the money script and go to Money>deductFunds(int) and input the amount the upgrade costs.
