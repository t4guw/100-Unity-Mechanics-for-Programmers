using UnityEngine;
using UnityEngine.UI;

public class HungerScript : MonoBehaviour
{
    public Slider hungerBar;
    public bool constantHungerLoss = true;
    float timer;

    void Update()
    {
        if (constantHungerLoss)
        {
            hungerBar.value -= 0.003f;
            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                hungerBar.value -= 0.003f;
            }
        }
        else
        {
            if (Time.time - timer > 5f)
            {
                hungerBar.value -= 10f;
                timer = Time.time;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Apple")
        {
            hungerBar.value += 50f;
            Destroy(collision.gameObject);
        }
        else if (collision.name == "Banana")
        {
            hungerBar.value += 25f;
            Destroy(collision.gameObject);
        }
    }

    public void HungerLossTypeSwitch()
    {
        constantHungerLoss = !constantHungerLoss;
        timer = Time.time;
    }
}
