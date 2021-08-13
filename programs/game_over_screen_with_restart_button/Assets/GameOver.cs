using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    bool gameOver = false;

    void Update()
    {
        if(gameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameOver = true;
    }

    // Called when restart button is clicked
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Scene1");
    }
}
