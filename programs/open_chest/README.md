# Open Chest

## Description
This mechanic shows how to implement an interactable chest that when opened, it will drop a random item from the given item array. 

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create/Find a png of an opened chest and a closed chest.
   2. Set the player's tag to "Player"
   3. Create a prefab of the closed chest and attach the following OpenChestScript to it.
   4. Put all desired items in the Chest Items array.
   5. Put the sprite for the open chest as the Chest Open variable.
   6. Attach Circle Collider 2D to the chest prefab and set the radius to desired distance allowed for opening.
   7. Attach Box Collider 2D and Rigidbody 2D to the player with Body Type set to "Kinematic" and Sleeping Mode to "Never Sleep".

    using UnityEngine;

    public class OpenChestScript : MonoBehaviour
    {
        public GameObject[] chestItems;
        public Sprite chestOpen;
        bool chestClosed = true;

        void OpenChest()
        {
            GetComponent<SpriteRenderer>().sprite = chestOpen;
            chestClosed = false;
            int itemIndex = Random.Range(0, chestItems.Length);
            GameObject item = Instantiate(chestItems[itemIndex]);
            Vector3 p = transform.position;
            p.x -= 1f;
            p.y -= 0.75f;
            item.transform.position = p;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Debug.Log("Collide");
                if (Input.GetKey(KeyCode.E) && chestClosed)
                {
                    OpenChest();
                }
            }
        }
    }