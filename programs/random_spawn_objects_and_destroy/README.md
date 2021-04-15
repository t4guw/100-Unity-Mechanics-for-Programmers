# Spawn Objects in Random Location and Destroy on Time Interval

## Description 
This mechanic shows how to implement spawning an object in a random location, and
destroying it over a specified timer interval. This could be useful when attempting
to spawn an enemy in a random position. This mechanic could easily be expanded to destroy the object
on a collision rather than a time interval.

## Implementation
There are several steps that need to be completed in the Unity Editor:
1. Create a new sprite renderer 2D object that will serve as the object/enemy.
2. Make the object from step 1 into a prefab by dragging it from the hierarchy into the Assets folder.
3. Create a new empty GameObject in the editor.
4. Add the following script to the object from step 3:

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