using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    Text coinCountText;
    int coinCount;
    void Start()
    {
        coinCountText = GameObject.Find("Coin Count").GetComponent<Text>();
        coinCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            coinCount++;
            Destroy(other.gameObject);
            coinCountText.text = "Coin Count: " + coinCount;
        }
    }
}
