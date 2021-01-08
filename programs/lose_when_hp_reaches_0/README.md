# Lose When HP Reaches 0

## Description
This mechanic shows how to implement a loss when player's HP reaches 0.

## Implementation
This implementation uses a health bar which is an optional mechanic for this implementation.
To view how to implement the health bar as well, refer to the [Health Bar](https://github.com/t4guw/100-Unity-Mechanics-for-Programmers/tree/master/programs/health_bar_2d) mechanic.

In the Unity Editor:
1. Create a canvas with a text object for the "You Died" text and a button to restart.
2. Attach the OnButtonClick() function from the Player script to the button.
3. Drag the canvas object into Player's canvas variable.
4. Set the canvas to inactive.

The following code will cause the player to lose if their HP reaches 0 with the option to restart.

using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameObject canvas;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= 15;
            healthBar.SetHealth(currentHealth);
        }
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            canvas.SetActive(true);
        }
    }

    public void OnButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}