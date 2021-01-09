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
