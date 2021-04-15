using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public GameObject popup;
    private bool activate = false;

    // Update is called once per frame
    public void Show()
    {
        popup.SetActive(activate);
        activate = !activate;
    }
}
