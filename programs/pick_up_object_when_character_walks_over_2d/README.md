# Pick Up Object When Character Walks Over 2D

## Description
This mechanic shows how to automatically have a character pick up an object by walking over it in 2D.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create a canvas and create UI Images for each inventory slot you want to have.
   2. As a child of the UI Images, make another UI Image for the icon of the item and set as inactive.
   3. Create a prefab for the item with a collider attached.
   4. On the character object, attach a collider, rigidbody, and the following ItemInteraction script.
    
   Once the inventory is full, objects will no longer be picked up.
    
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

