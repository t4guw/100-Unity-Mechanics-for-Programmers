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
