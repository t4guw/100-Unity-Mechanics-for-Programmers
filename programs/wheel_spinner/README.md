# Wheel Spinner

## Description
This mechanic shows how to implement wheel that the player can spin to earn a prize.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create a canvas and add the wheel to it.
   2. Create each section for the wheel as a child.
   3. Add Polygon Collider to each of the sections.
   4. Add a Text UI to each section as a child.
   5. Create a Triangle Sprite at the top of the wheel to indicate the selection.
   6. Add Polygon Collier to the triangle.
   7. Attach the WheelScript to the wheel object.
   8. Attach the SectionScript to each of the sections.
   9. Create a button to allow the user to spin the wheel.
   10. Put the SpinWheel() function in the OnClick() for the button.

    using UnityEngine;
    using UnityEngine.UI;

    public class WheelScript : MonoBehaviour
    {
        public Text selectedText;
        bool spinning = false;
        float spinSpeed;

        void Update()
        {
            if (spinning)
            {
                transform.Rotate(0, 0, spinSpeed);
                if (spinSpeed < 1f)
                {
                    spinSpeed -= 0.001f;
                }
                else
                {
                    spinSpeed -= 0.01f;
                }
                if (spinSpeed < 0)
                {
                    spinSpeed = 0;
                    spinning = false;
                }
            }
        }

        public void SpinWheel()
        {
            spinSpeed = Random.Range(4f, 8f);
            spinning = true;
        }
    }

##

    using UnityEngine;
    using UnityEngine.UI;

    public class SectionScript : MonoBehaviour
    {
        Color originalColor;
        SpriteRenderer sRenderer;
        Text prizeText;

        private void OnDisable()
        {
            sRenderer.material.color = originalColor;
        }

        void Start()
        {
            sRenderer = GetComponent<SpriteRenderer>();
            originalColor = sRenderer.material.color;
            prizeText = GameObject.Find("Prize Text").GetComponent<Text>();
        }

        void OnTriggerStay2D(Collider2D collision)
        {
            sRenderer.material.color = Color.green;
            prizeText.text = "Prize: " + gameObject.transform.GetChild(0).name;
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            sRenderer.material.color = originalColor;
        }
    }