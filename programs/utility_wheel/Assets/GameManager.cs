using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int maxWheels = 2;
    int currentWheel = 0;

    public GameObject[] utilityWheel;
    public GameObject wheelTracker;
    public Text[] wheelText;
    public Text selectedText;

    Vector3 location = new Vector3(0, 250, 0);

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            utilityWheel[currentWheel].SetActive(true);
            wheelTracker.SetActive(true);
            selectedText.gameObject.transform.localPosition = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                wheelText[currentWheel].color = Color.grey;
                utilityWheel[currentWheel].SetActive(false);
                if (currentWheel == maxWheels - 1)
                {
                    currentWheel = 0;
                }
                else
                {
                    currentWheel++;
                }
                wheelText[currentWheel].color = Color.white;
                utilityWheel[currentWheel].SetActive(true);
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            utilityWheel[currentWheel].SetActive(false);
            wheelTracker.SetActive(false);
            selectedText.gameObject.transform.localPosition = location;
            currentWheel = 0;
        }
    }
}