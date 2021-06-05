# Utility Wheel

## Description
This mechanic shows how to implement a utility wheel used to select items such as tools/weapons.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create a canvas and add the utility wheel to it.
   2. Create each section for the utility wheel.
   3. Add a polygon collider to each section and adjust it to extend out to the edge of the screen.
   4. Add a corresponding image as a child to each section.
   5. Copy the utility wheel and paste it to make the desired number of wheels.
   6. Create a UI text to show the selected tool.
   7. Create another UI text for each wheel you created to indicate the currently selected wheel.
   8. Set the previous UI texts made in step 7 as children of an empty gameObject.
   9. Attach the following Utility script to each section object.
   10. Attach the following GameManager script to the Canvas.
   11. Drag the corresponding variables to the public variables of GameManager and set both array sizes to the number of wheels.
    
  
    
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
        int maxWheels = 2;
        int currentWheel = 0;

        public GameObject[] utilityWheel;
        public GameObject wheelTracker;
        public Text[] wheelText;
        public Text selectedText;

        Vector3 location = new Vector3(0, 250, 0);

        void Update()
        {
            if (Input.GetMouseButton(1))
            {
                utilityWheel[currentWheel].SetActive(true);
                wheelTracker.SetActive(true);
                selectedText.gameObject.transform.localPosition = Vector3.zero;
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    wheelText[currentWheel].color = Color.grey;
                    utilityWheel[currentWheel].SetActive(false);
                    if (currentWheel == maxWheels - 1)
                    {
                        currentWheel = 0;
                    }
                    else
                    {
                        currentWheel++;
                    }
                    wheelText[currentWheel].color = Color.white;
                    utilityWheel[currentWheel].SetActive(true);
                }
            }

            if (Input.GetMouseButtonUp(1))
            {
                utilityWheel[currentWheel].SetActive(false);
                wheelTracker.SetActive(false);
                selectedText.gameObject.transform.localPosition = location;
                currentWheel = 0;
            }
        }
    }

