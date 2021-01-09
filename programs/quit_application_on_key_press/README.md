# Quit Application on Key Press

## Description
This mechanic shows how to implement a quit application feature.

## Implementation
The following code shows implements the quit application when either the Q key or Esc key is pressed. Any key can be set to trigger the application quit.

    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown("q") || Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }

