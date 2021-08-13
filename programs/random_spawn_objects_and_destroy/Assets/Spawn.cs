using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    float timer = 2f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            SpawnObject();
            timer = 0f;
        }    
    }

    private void SpawnObject()
    {
        bool objSpawned = false;
        while (!objSpawned)
        {
            Vector3 objPosition = new Vector3(Random.Range(-9f, 9f), Random.Range(-4f, 4f), 0);
            // ensures new object is spawned far enough away
            if ((objPosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                objSpawned = true;
                Destroy(Instantiate(enemy, objPosition, Quaternion.identity), 2.0f);
            }
        }
        
    }
}
