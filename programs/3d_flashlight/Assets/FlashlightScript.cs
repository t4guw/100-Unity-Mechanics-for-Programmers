using UnityEngine;

public class FlashlightScript : MonoBehaviour
{
    bool flashlightOn;

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        flashlightOn = false;
        RenderSettings.reflectionIntensity = 0.2f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlightOn)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                flashlightOn = false;
                RenderSettings.reflectionIntensity = 0.2f;
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
                flashlightOn = true;
                RenderSettings.reflectionIntensity = 0.5f;
            }
        }
    }
}
