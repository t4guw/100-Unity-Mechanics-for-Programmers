using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    float mouseSens = 500f;
    public Transform playerBody;
    float xRotation = 0f;
    public Slider sensitivitySlider;
    public Text sensitivityText;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        sensitivityText.text = "Sensitivity: " + mouseSens;
        sensitivitySlider.value = mouseSens;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                if (mouseSens > 50)
                {
                    mouseSens -= 50f;
                    sensitivityText.text = "Sensitivity: " + mouseSens;
                    sensitivitySlider.value = mouseSens;
                }
            }
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                if (mouseSens < 500)
                {
                    mouseSens += 50f;
                    sensitivityText.text = "Sensitivity: " + mouseSens;
                    sensitivitySlider.value = mouseSens;
                }
            }
            float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    public void UpdateSlider()
    {
        mouseSens = sensitivitySlider.value;
        sensitivityText.text = "Sensitivity: " + mouseSens;
    }
}
