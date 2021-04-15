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
