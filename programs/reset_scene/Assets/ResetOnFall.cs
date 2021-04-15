using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetOnFall : MonoBehaviour
{
    void OnTriggerEnter2D()
    {
        SceneManager.LoadScene("Level1");
    }
}
