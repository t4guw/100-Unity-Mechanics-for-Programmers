# Show Text UI on Mouse Hover

## Description
This mechanic will show how to show text UI when the mouse is hovered over an object.

## Implementation
There are several steps that need to be taken in the Unity Editor.

    1. Create as many gameObjects as needed.
    2. Create a canvas and a text UI for each of the gameObjects.
    3. Create a custom tag for each gameObject and the corresponding text UI.
    4. Set all the text UI to inactive.
    5. Attach the MouseHover script to each gameObject that has a corresponding text UI.


    using UnityEngine;

    public class MouseHover : MonoBehaviour
    {
        GameObject canvas;

        void Start()
        {
            canvas = GameObject.Find("Canvas");
        }

        private void OnMouseEnter()
        {
            for (int i = 0; i < canvas.transform.childCount; i++)
            {
                if (canvas.transform.GetChild(i).tag == tag)
                {
                    canvas.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }

        private void OnMouseExit()
        {
            for (int i = 0; i < canvas.transform.childCount; i++)
            {
                canvas.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

