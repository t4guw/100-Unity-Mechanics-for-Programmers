using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private const int kMaxInventorySize = 3;
    // Used to keep track of used inventory slots
    private bool[] inventory = new bool[kMaxInventorySize];
    private bool itemAdded = false;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < kMaxInventorySize; i++)
        {
            if (inventory[i] == false && !itemAdded)
            {
                Destroy(other.gameObject);
                GameObject inventorySlot = GameObject.Find("Inventory " + i);
                inventorySlot.transform.GetChild(0).gameObject.SetActive(true);
                inventory[i] = true;
                itemAdded = true;
            }
        }
        itemAdded = false;
    }
}
