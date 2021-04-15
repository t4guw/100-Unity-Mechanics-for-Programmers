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
