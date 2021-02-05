using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float secRemaining = 90f;
    bool timerEnded = false;

    void Update()
    {

        if (!timerEnded)
        {
            if (secRemaining > 1)
            {
                secRemaining -= Time.deltaTime;
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