# Manipulate Object Size

## Description 
This mechanic shows how to increase and decrease an objects size during runtime.

## Implementation
There are several steps that need to be completed in the Unity Editor:

   1. Add a Polygon Collier 2D to objects the objects that will be manipulated and check Is Trigger.
   2. Change the tag on the objects to "Item".
   3. Create a Game Manager object and attach the ItemBehavior script to it


    using UnityEngine;
    using UnityEngine.UI;

    public class ItemBehavior : MonoBehaviour
    {
        GameObject selectedObject;
        public Text selectedText;

        void Update()
        {
            if (selectedObject != null)
            {
                Vector3 s = selectedObject.transform.localScale;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    s.x += 0.005f;
                    s.y += 0.005f;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (s.x >= 0.25f && s.y >= 0.25f)
                    {
                        s.x -= 0.005f;
                        s.y -= 0.005f;
                    }
                }
                selectedObject.transform.localScale = s;
            }

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 50f);
            if (hit.collider != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.tag == "Item")
                    {
                        selectedObject = hit.collider.gameObject;
                        selectedText.text = "Currently Selected: " + hit.collider.name;
                    }
                    else
                    {
                        selectedObject = null;
                        selectedText.text = "Currently Selected: None";
                    }
                }
            }
        }
    }
