using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCost : MonoBehaviour
{

    public GameObject player;
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Money>().currentFunds() < cost)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
    }
}
