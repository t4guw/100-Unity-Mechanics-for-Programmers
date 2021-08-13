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