using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSquare : MonoBehaviour
{
    public GameObject platformPrefab;
    private GameObject currentPlatform;
    private Transform _transform;
    private List<GameObject> platformList;

    private Vector3 startClick;

    // Start is called before the first frame update
    void Start()
    {
        platformList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreatePlatform();
        }
        if (Input.GetMouseButton(0))
        {
            UpdatePlatform();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            DeletePlatform();
        }
    }

    void CreatePlatform()
    {
        startClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        currentPlatform = Instantiate(platformPrefab, Vector3.zero, Quaternion.identity);
        _transform = currentPlatform.transform;
        _transform.position = new Vector3(startClick.x, startClick.y, 1);
        platformList.Add(currentPlatform);
    }

    void UpdatePlatform()
    {
        Vector3 tempClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = startClick.x - tempClick.x;
        float y = startClick.y - tempClick.y;
        _transform.localScale = new Vector3(x, y, _transform.localScale.z);
        Vector3 drag = Vector3.Lerp(startClick, tempClick, 0.5f);

        _transform.position = new Vector3(drag.x, drag.y, _transform.position.z);
    }

    private void DeletePlatform()
    {
        if (platformList.Count > 0)
        {
            GameObject tempObj = platformList[platformList.Count - 1];
            platformList.RemoveAt(platformList.Count - 1);
            Destroy(tempObj);
        }
    }
}
