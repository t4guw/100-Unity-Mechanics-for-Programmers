using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ballPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Spawn(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    void Spawn(Vector3 mousePos)
    {
        GameObject newBall = Instantiate(ballPrefab);
        newBall.transform.position = new Vector3(mousePos.x, mousePos.y, 2);
    }
}
