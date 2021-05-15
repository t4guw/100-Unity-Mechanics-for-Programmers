using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    int maxHealth;
    float timer;

    void Start()
    {
        maxHealth = 100;
        timer = 0;
        SetMaxHealth(maxHealth);
        SetHealth(maxHealth);
    }

    void Update()
    {
        if ((Time.time - timer) > 0.1)
        {
            SetHealth(maxHealth--);
            timer = Time.time;
        }
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
