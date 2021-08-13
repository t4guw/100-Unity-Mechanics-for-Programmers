using UnityEngine;
using UnityEngine.UI;

public class ItemInteraction : MonoBehaviour
{
    private const int kMaxInventorySize = 3;
    // Used to keep track of used inventory slots
    private bool[] inventory = new bool[kMaxInventorySize];
    private bool itemAdded = false;
    public Slider healthSlider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem(2);
        }

        if (healthSlider.value <= 0)
        {
            Vector3 itemDropLoc = transform.position;
            itemDropLoc.y -= 0.25f;
            for (int i = 0; i < kMaxInventorySize; i++)
            {
                if (inventory[i])
                {
                    GameObject banana = Instantiate(Resources.Load("Prefab/Banana") as GameObject);
                    banana.transform.position = itemDropLoc;
                    GameObject inventorySlot = GameObject.Find("Inventory " + i);
                    inventorySlot.transform.GetChild(0).gameObject.SetActive(false);
                    inventory[i] = false;
                    itemDropLoc.x -= 1f;
                }
            }
            Destroy(this.gameObject);
        }
    }

    void UseItem(int inventoryIndex)
    {
        if (inventory[inventoryIndex] == true)
        {
            GameObject bananaPeel = Instantiate(Resources.Load("Prefab/BananaPeel") as GameObject);
            Vector3 p = this.transform.localPosition;
            p.y -= 0.3f;
            p.x -= 1f;
            bananaPeel.transform.localPosition = p;
            GameObject inventorySlot = GameObject.Find("Inventory " + inventoryIndex);
            inventorySlot.transform.GetChild(0).gameObject.SetActive(false);
            inventory[inventoryIndex] = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
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
