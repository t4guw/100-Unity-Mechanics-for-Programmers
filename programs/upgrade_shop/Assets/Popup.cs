using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject popup;
    public KeyCode input;
    private bool activate = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKeyDown(input))
            {
                popup.SetActive(activate);
                activate = !activate;
            }
        }
    }
}
