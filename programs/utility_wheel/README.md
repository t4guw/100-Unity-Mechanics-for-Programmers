# Utility Wheel

## Description
This mechanic shows how to implement a utility wheel used to select items such as tools/weapons.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create a canvas and add the utility wheel to it.
   2. Create each section for the utility wheel.
   3. Add a polygon collider to each section and adjust it to extend out to the edge of the screen.
   4. Add a corresponding image as a child to each section.
   5. Create a UI text to show the selected tool.
   6. Attach the following Utility script to each section object.
   7. Attach the following GameManager script to the Canvas.
   8. Drag the Utility Wheel and SelectedText to the public variables of GameManager
    
  
    
    using UnityEngine;
    using UnityEngine.UI;

    public class Utility : MonoBehaviour
    {
        Color originalColor;
        SpriteRenderer sRenderer;
        Text selectedText;

        private void OnDisable()
        {
            sRenderer.material.color = originalColor;
        }

        void Start()
        {
            sRenderer = GetComponent<SpriteRenderer>();
            originalColor = sRenderer.material.color;
            selectedText = GameObject.Find("SelectedText").GetComponent<Text>();
        }

        void OnMouseOver()
        {
            sRenderer.material.color = Color.green;
            selectedText.text = "Selected: " + gameObject.transform.GetChild(0).name;
        }

        void OnMouseExit()
        {
            sRenderer.material.color = originalColor;
            selectedText.text = "Selected: Nothing";
        }
    }

###

    using UnityEngine;
    using UnityEngine.UI;

    public class GameManager : MonoBehaviour
    {
        public GameObject UtilityWheel;
        public Text selectedText;
        Vector3 location = new Vector3(0, 250, 0);

        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                UtilityWheel.SetActive(true);
                selectedText.gameObject.transform.localPosition = Vector3.zero;
            }

            if (Input.GetMouseButtonUp(1))
            {
                UtilityWheel.SetActive(false);
                selectedText.gameObject.transform.localPosition = location;
            }
        }
    }

