using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int startingMoney = 500;
    private int currentMoney;
    public GameObject moneyCounter;
    private TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {
        currentMoney = startingMoney;
        textMesh = moneyCounter.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textMesh.text = currentMoney.ToString();
    }

    public void addFunds(int newFunds)
    {
        currentMoney += newFunds;
    }

    public int currentFunds()
    {
        return currentMoney;
    }

    public void deductFunds(int fee)
    {
        currentMoney -= fee;
    }

}
