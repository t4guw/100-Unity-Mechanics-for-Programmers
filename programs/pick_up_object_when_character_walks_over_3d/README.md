# Pick Up Objects When Character Walks Over in 3D

## Description
This mechanic shows how to implement a character picking up objects automatically when walking over it in 3D.

## Implementation
There are several steps that need to be done in the Unity Editor.
To view how to set up the character movement in 3D, refer to the [First Person Movement 3D](https://github.com/t4guw/100-Unity-Mechanics-for-Programmers/tree/master/programs/first_person_movement_3d) mechanic.

   1. Create desired item(s) to put in the world.
   2. Attach a collider to the item(s) and check the Is Trigger in it's inspector.
   3. On your player, attach the following ItemIteraction script.

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