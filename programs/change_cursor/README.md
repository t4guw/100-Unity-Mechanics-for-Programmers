# Change Mouse Cursor

## Description
This mechanic shows how to change the mouse cursor. It shows how to change the normal cursor, as well as on certain events, such as
clicking the mouse or hovering over an object.

## Implementation
The best and most versatile way to change the cursor is via sprites. There are several steps that need to be done in the Unity Editor.
The cursors used in the example program can be found [here](https://assetstore.unity.com/packages/2d/gui/icons/pixel-cursors-109256#reviews).

1. Create a new 2D sprite and add the desired default cursor to the sprite property
2. Attach the below script to the newly created game object. This example code also shows how to change the cursor on holding left mouse click.

        using UnityEngine;

        public class cursorControl : MonoBehaviour
        {
            public SpriteRenderer rend;
            public Sprite defaultCursor;
            public Sprite tempCursor;

            void Start()
            {
                Cursor.visible = false;
                rend = GetComponent<SpriteRenderer>();
            }

            void Update()
            {
                Cursor.visible = false;
                Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = cursorPos;

                if (Input.GetMouseButtonDown(0))
                {
                    rend.sprite = tempCursor;
                } else if (Input.GetMouseButtonUp(0))
                {
                    rend.sprite = defaultCursor;
                }
            }
        }
3. Attach the below script to the desired object that you would like to change the cursor. It will change the cursor when the mouse hovers over it, and change the cursor back when it leaves the object. 

        using UnityEngine;

        public class changeCursor : MonoBehaviour
        {
            public Sprite defaultCursor;
            public Sprite tempCursor;
            [SerializeField]cursorControl cursor;

            private void OnMouseEnter()
            {
                cursor.rend.sprite = tempCursor;
            }

            private void OnMouseExit()
            {
                cursor.rend.sprite = defaultCursor;
            }
        }

4. Make sure to drag and drop the desired cursors to the objects' fields in the Unity editor.