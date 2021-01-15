# Use Items On Key Press

## Description
This mechanic shows how to use an item in the inventory with a key press.

## Implementation
To view the steps to on how to pick up items, please reference [this](https://github.com/t4guw/100-Unity-Mechanics-for-Programmers/tree/master/programs/pick_up_object_when_character_walks_over).
    
    using UnityEngine;

    public class ItemInteraction : MonoBehaviour
    {
        private const int kMaxInventorySize = 3;
	    // Used to keep track of used inventory slots
        private bool[] inventory = new bool[kMaxInventorySize];
        private bool itemAdded = false;

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
        }

        void UseItem(int inventoryIndex)
        {
            if (inventory[inventoryIndex] == true)
            {
                GameObject banana = Instantiate(Resources.Load("Prefab/Banana") as GameObject);
                Debug.Log(banana);
                Vector3 p = this.transform.localPosition;
                p.y += 1;
                p.x += 1;
                banana.transform.localPosition = p;
                GameObject inventorySlot = GameObject.Find("Inventory " + inventoryIndex);
                inventorySlot.transform.GetChild(0).gameObject.SetActive(false);
                inventory[inventoryIndex] = false;
            }
        }        
    }

