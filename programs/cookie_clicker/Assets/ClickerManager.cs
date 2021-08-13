using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerManager : MonoBehaviour
{
    public GameObject clickerObj;
    private List<GameObject> clickerList;
    private int clickerCount = 0;
    public float clickerInterval = 2f;
    private double numberInterval;
    private double clickerTimer = 0;
    private int clickerClick = 0;
    private Cookie cookie;

    // Start is called before the first frame update
    void Start()
    {
        cookie = gameObject.GetComponentInParent<Cookie>();
        clickerList = new List<GameObject>();
        SpawnClicker();
    }

    // Update is called once per frame
    void Update()
    {
        clickerTimer += Time.deltaTime;
        if(clickerTimer >= numberInterval)
        {
            ClickClicker();
            clickerTimer = 0;
        }
    }

    private void ClickClicker()
    {
        cookie.ClickCookie();

        // AFAIK You can't actually have a GameObject click a button so we'll make it look like it's clicking the button
        clickerList[clickerClick].GetComponent<Clicker>().Click();
        clickerClick++;
        if (clickerClick == clickerList.Count)
        {
            clickerClick = 0;
        }

    }

    public void SpawnClicker()
    {
        clickerCount++;
        numberInterval = clickerInterval / clickerCount;
        GameObject newClicker = Instantiate(clickerObj);
        newClicker.name = "Clicker" + clickerCount;
        newClicker.transform.parent = transform;
        newClicker.transform.position = new Vector3(0f, -1.8f, 0);
        clickerList.Add(newClicker);
        RepositionClickers();
    }

    private void RepositionClickers()
    {
        // Determine Theta for Circile Coordinates
        float theta = (2 * Mathf.PI) / clickerCount;

        // Update all Clickers
        for (int i = 0; i < clickerList.Count; i++)
        {
            // Update Clicker Position
            clickerList[i].transform.position = new Vector3(1.8f * Mathf.Cos(theta*i), 1.8f * Mathf.Sin(theta * i));
            
            // Update Clicker Rotation
            Vector3 direction = transform.position - clickerList[i].transform.position;
            clickerList[i].transform.up = direction;
        }
    }
}
