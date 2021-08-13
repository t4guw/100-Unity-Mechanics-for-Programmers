using UnityEngine;
using UnityEngine.UI;

public class WheelScript : MonoBehaviour
{
    public Text selectedText;
    bool spinning = false;
    float spinSpeed;

    void Update()
    {
        if (spinning)
        {
            transform.Rotate(0, 0, spinSpeed);
            if (spinSpeed < 1f)
            {
                spinSpeed -= 0.001f;
            }
            else
            {
                spinSpeed -= 0.01f;
            }
            if (spinSpeed < 0)
            {
                spinSpeed = 0;
                spinning = false;
            }
        }
    }

    public void SpinWheel()
    {
        spinSpeed = Random.Range(4f, 8f);
        spinning = true;
    }
}