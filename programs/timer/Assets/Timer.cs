using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider slider;
    float secRemaining = 90f;
    bool timerEnded = false;

    void Start()
    {
        slider.maxValue = secRemaining;
        slider.value = secRemaining - 1f;
    }

    void Update()
    {

        if (!timerEnded)
        {
            if (secRemaining > 1)
            {
                secRemaining -= Time.deltaTime;
                slider.value -= Time.deltaTime;
                float minutes = Mathf.FloorToInt(secRemaining / 60);
                float seconds = Mathf.FloorToInt(secRemaining % 60);
                this.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else
            {
                this.GetComponent<Text>().color = new Color(150f, 0f, 0f);
            }
        }
    }
}