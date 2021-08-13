# Checkpoint System 3D

## Description
This mechanic shows how to implement checkpoint system in 3D space.

## Implementation
There are several steps that need to be done in the Unity Editor.
To view how to set up the character movement in 3D, refer to the [First Person Movement 3D](https://github.com/t4guw/100-Unity-Mechanics-for-Programmers/tree/master/programs/first_person_movement_3d) mechanic.

   1. Create a cylinder prefab to act as the checkpoint.
   2. Attach a material that is semi-transparent to the prefab.
   3. Create an empty GameObject to be the parent of all the checkpoint prefabs.
   4. Attach the following Checkpoint script to the Player gameobject.

    using UnityEngine;

    public class Checkpoints : MonoBehaviour
    {
        public GameObject checkpoints;
        int currentCheckpoint;

        void Start()
        {
            currentCheckpoint = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Checkpoint")
            {
                checkpoints.transform.GetChild(currentCheckpoint).gameObject.SetActive(false);
                currentCheckpoint++;
                if(currentCheckpoint == checkpoints.transform.childCount)
                {
                    currentCheckpoint = 0;
                }
                checkpoints.transform.GetChild(currentCheckpoint).gameObject.SetActive(true);
            }
        }
    }
