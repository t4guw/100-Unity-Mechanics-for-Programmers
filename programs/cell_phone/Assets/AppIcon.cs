using UnityEngine;
using UnityEngine.UI;

public class AppIcon : MonoBehaviour
{
    Text appNameText;

    void Start()
    {
        appNameText = GameObject.Find("AppName").GetComponent<Text>();
    }

    private void OnMouseEnter()
    {
        appNameText.text = name;
    }

    private void OnMouseExit()
    {
        appNameText.text = "";
    }
}
