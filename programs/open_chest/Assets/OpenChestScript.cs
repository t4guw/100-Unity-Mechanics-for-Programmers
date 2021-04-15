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