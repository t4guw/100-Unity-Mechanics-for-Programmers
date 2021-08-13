using UnityEngine;
using UnityEngine.UI;

public class DiceCheck : MonoBehaviour
{
    public Text diceNumberText;
    public GameObject[] dice;
    public Dropdown numDiceDropdown;
    int totalDiceSum;
    bool allStopped;
    Vector3 diceVelocity;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            totalDiceSum = 0;
            ResetColliders();
        }

        allStopped = true;
        for (int i = 0; i < dice.Length; i++)
        {
            diceVelocity = dice[i].GetComponent<DiceBehavior>().diceVelocity;
            if (diceVelocity.x != 0f || diceVelocity.y != 0f && diceVelocity.z != 0f)
            {
                allStopped = false;
            }
        }
        if (allStopped)
        {
            diceNumberText.text = totalDiceSum.ToString();
        }
    }

    void OnTriggerStay(Collider collision)
    {
        diceVelocity = collision.transform.parent.GetComponent<DiceBehavior>().diceVelocity;
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            switch (collision.gameObject.name)
            {
                case "Side 1":
                    totalDiceSum += 6;
                    break;
                case "Side 2":
                    totalDiceSum += 5;
                    break;
                case "Side 3":
                    totalDiceSum += 4;
                    break;
                case "Side 4":
                    totalDiceSum += 3;
                    break;
                case "Side 5":
                    totalDiceSum += 2;
                    break;
                case "Side 6":
                    totalDiceSum += 1;
                    break;
            }
            collision.gameObject.SetActive(false);
        }
    }

    public void NumDiceChanged()
    {
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i].GetComponent<DiceBehavior>().enabled = false;
            dice[i].transform.position = new Vector3(0, -50f, 0);
        }
        dice = new GameObject[numDiceDropdown.value];
        for (int i = 0; i < dice.Length; i++)
        {
            dice[i] = GameObject.Find("dice " + (i + 1));
            dice[i].GetComponent<DiceBehavior>().enabled = true;
        }
    }

    void ResetColliders()
    {
        for (int i = 0; i < dice.Length; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                dice[i].transform.GetChild(j).gameObject.SetActive(true);
            }
        }
    }
}
