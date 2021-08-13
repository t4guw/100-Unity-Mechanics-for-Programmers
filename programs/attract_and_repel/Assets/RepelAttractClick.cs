using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelAttractClick : MonoBehaviour
{
    private GameObject attract;
    private GameObject repel;
    // Start is called before the first frame update
    void Start()
    {
        attract = GameObject.FindGameObjectWithTag("Attract");
        attract.SetActive(false);
        repel = GameObject.FindGameObjectWithTag("Repel");
        repel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attract.SetActive(true);
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonDown(1))
        {
            repel.SetActive(true);
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            attract.SetActive(false);
        }
        if (Input.GetMouseButtonUp(1))
        {
            repel.SetActive(false);
        }
    }
}
