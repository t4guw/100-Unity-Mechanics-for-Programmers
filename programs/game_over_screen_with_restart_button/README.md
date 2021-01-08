# Game Over Screen with Restart Button

## Description
This mechanic will show how to make a game over screen.

## Implementation
There are several steps that need to be taken in the Unity Editor.

    1. Create a UI Image to be your game over screen background (Customize as you see fit).
    2. Create a button and in the inspector, set the On Click () to reference the OnButtonClick() function from the GameOver script.
    3. Change the button text to "Restart".
    4. Set the parent image to inactive.
    5. Drag and drop the parent image into the gameOverScreen variable for the GameOver script.
    *Anything added to the game over screen should be set as a child of the background image.*

The following code changes the bool gameOver to true when it detects a collison. It can be modified to trigger the game over screen wherever gameOver gets set to true.
###
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

