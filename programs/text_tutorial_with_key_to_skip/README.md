# Text Tutorial with Key to Skip

## Description
This mechanic will show how to make a tutorial for any game or application.

## Implementation
There are several steps that need to be taken in the Unity Editor.

    1. Create a canvas and other UI objects that will show up on all pages (i.e. NextButton, PreviousButton, PageNumber, etc.).
    2. For each page that the tutorial has, create an empty gameObject within the canvas.
    3. In each empty gameObject, create whatever will be included on that page as a child.
    4. Attach the script below to the canvas and attach gameObjects to corresponding public variables.
    5. Set the size of the Pages array to the amount of pages in the tutorial and drag each page into the elements. 

using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : MonoBehaviour
{
    int pageNum = 1;
    //Change this number to the number of desired tutorial pages
    const int kMaxPageNum = 3;

    public Text pageNumText;
    public GameObject[] pages;
    public GameObject previousButton;

    void Start()
    {
        UpdatePageContent();        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            gameObject.SetActive(false);
        }
    }


    public void NextButtonClicked()
    {
        if (pageNum < kMaxPageNum)
        {
            pageNum++;
        }
        else if (pageNum == kMaxPageNum)
        {
            gameObject.SetActive(false);
        }
        UpdatePageContent();
    }

    public void PreviousButtonClicked()
    {
        if (pageNum > 1)
        {
            pageNum--;
        }
        UpdatePageContent();
    }

    void UpdatePageContent()
    {
        pageNumText.text = "Page " + pageNum + " / " + kMaxPageNum;
        for (int i = 0; i < kMaxPageNum; i++)
        {
            if (i == pageNum - 1)
            {
                pages[i].SetActive(true);
            }
            else
            {
                pages[i].SetActive(false);
            }
        }
        if(pageNum == 1)
        {
            previousButton.SetActive(false);
        }
        else
        {
            previousButton.SetActive(true);
        }
    }
}

