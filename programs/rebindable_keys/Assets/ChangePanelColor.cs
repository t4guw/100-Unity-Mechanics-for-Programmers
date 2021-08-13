using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangePanelColor : MonoBehaviour
{
    Image img;

    Color original;

    // Use this for initialization
    void Start()
    {
        img = gameObject.GetComponent<Image>();
        original = img.color;
    }

    public void ChangeColor()
    {
        if (img.color == UnityEngine.Color.red)
        {
            img.color = original;
        } else
        {
            img.color = UnityEngine.Color.red;
        }
    }
}