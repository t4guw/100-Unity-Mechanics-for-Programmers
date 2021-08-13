using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cookie : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int cookieCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ClickCookie()
    {
        string msg = "";
        cookieCount++;
        msg += cookieCount;
        text.text = msg;
    }
}
