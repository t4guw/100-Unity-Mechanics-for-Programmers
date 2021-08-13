using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    private float clickTime = 0.1f;
    private float clickTimer = 0f;
    private bool clicked = false;
    private GameObject cookie;

    // Start is called before the first frame update
    void Start()
    {
        // Grab cookie button
        cookie = GameObject.FindGameObjectWithTag("Cookie");
    }

    // Update is called once per frame
    void Update()
    {
        if (clicked)
        {
            clickTimer += Time.deltaTime;
            if (clickTimer > clickTime)
            {
                Unclick();
                clickTimer = 0;
            }
        }
    }

    public void Click()
    {
        // AFAIK You can't actually have a GameObject click a button so we'll make it look like it's clicking the button
        ColorBlock pressed = cookie.GetComponent<Button>().colors;
        pressed.normalColor = new Color(.78f, .78f, .78f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.8f, 0.8f);
        cookie.GetComponent<Button>().colors = pressed;
        clicked = true;
    }

    public void Unclick()
    {
        ColorBlock unpressed = cookie.GetComponent<Button>().colors;
        unpressed.normalColor = new Color(1f,1f,1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
        cookie.GetComponent<Button>().colors = unpressed;
        clicked = false;
    }

}
