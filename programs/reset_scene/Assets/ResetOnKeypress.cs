using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnKeypress : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
