using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnDelay = 1f;
    private float spawnTimer = 0;
    private GameObject currentObject;
    void Start()
    {
        currentObject = Instantiate(prefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentObject == null)
        {
            if (spawnTimer == 0)
            {
                spawnTimer = Time.time + spawnDelay;
            }
            if(Time.time > spawnTimer)
            {
                currentObject = Instantiate(prefab, transform.position, transform.rotation);
            }
        }
    }
}
