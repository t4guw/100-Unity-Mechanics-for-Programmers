using UnityEngine;
using UnityEngine.UI;

public class DiceCheck : MonoBehaviour
{
    public Text diceNumberText;
    int diceNum;
    Vector3 diceVelocity;

    void FixedUpdate()
    {
        diceVelocity = DiceBehavior.diceVelocity;
    }

    void OnTriggerStay(Collider collision)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            switch (collision.gameObject.name)
            {
                case "Side 1":
                    diceNum = 6;
                    break;
                case "Side 2":
                    diceNum = 5;
                    break;
                case "Side 3":
                    diceNum = 4;
                    break;
                case "Side 4":
                    diceNum = 3;
                    break;
                case "Side 5":
                    diceNum = 2;
                    break;
                case "Side 6":
                    diceNum = 1;
                    break;
            }
            diceNumberText.text = diceNum.ToString();
        }
    }
}
