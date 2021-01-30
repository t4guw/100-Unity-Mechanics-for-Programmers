# Arrow Buttons to Make a Choice

## Description
This mechanic will show how to allow the player to make a choice using arrow buttons or the arrow keys. This implementation has the palyer make a choice
of the background color. This can be edited to have the player make any choice.

## Implementation
There are several steps that need to be taken in the Unity Editor.

   1. Create a canvas with each of the choices availble to select.
   2. Add two buttons for 'Back' and 'Next and set their source image to arrows.
   3. Add an object to indicate which choice is currently selected.
   4. Attach the Selection script to the canvas.
   5. Set the size of SelectionArray in the Unity Inspector to the number of choice the player has.
   6. Drag the corresponding objects to the variables in the Unity Inspector.
   7. Add the NextButton() to the OnClick() for Next Button object.
   8. Add the BackButton() to the OnClick() for Back Button object.
   9. Add the SubmitButton() to the OnClick() for Submit Button object.
   

using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour
{
    public Image[] selectionArray;
    public GameObject selectedIndicator;
    public Camera mainCamera;
    int currentlySelected = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BackButton();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextButton();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SubmitButton();
        }
    }

    public void NextButton()
    {
        if (currentlySelected < selectionArray.Length - 1)
        {
            currentlySelected++;
            Vector3 p = selectionArray[currentlySelected].transform.localPosition;
            p.y -= 75f;
            selectedIndicator.transform.localPosition = p;
        }
    }

    public void BackButton()
    {
        if (currentlySelected > 0)
        {
            currentlySelected--;
            Vector3 p = selectionArray[currentlySelected].transform.localPosition;
            p.y -= 75f;
            selectedIndicator.transform.localPosition = p;
        }
    }

    public void SubmitButton()
    {
        mainCamera.backgroundColor = selectionArray[currentlySelected].color;
    }
}
