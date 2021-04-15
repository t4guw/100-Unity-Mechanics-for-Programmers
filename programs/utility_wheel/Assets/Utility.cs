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
