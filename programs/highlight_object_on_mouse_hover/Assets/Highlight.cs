using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highlight : MonoBehaviour
{
    public GameObject highlight;
    private Image img;
    private Color original = new Color(0.59f, 0.41f, 0.25f, 1.0f);
    private Color dark = new Color(0.55f, 0.37f, 0.21f, 1.0f);

    private void Start()
    {
        img = gameObject.GetComponent<Image>();
    }

    public void OnMouseOver()
    {
        highlight.SetActive(true);
        img.color = dark;
    }

    public void OnMouseExit()
    {
        highlight.SetActive(false);
        img.color = original;
    }
}
