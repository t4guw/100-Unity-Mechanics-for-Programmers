using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject UtilityWheel;
    public Text selectedText;
    Vector3 location = new Vector3(0, 250, 0);

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            UtilityWheel.SetActive(true);
            selectedText.gameObject.transform.localPosition = Vector3.zero;
        }

        if (Input.GetMouseButtonUp(1))
        {
            UtilityWheel.SetActive(false);
            selectedText.gameObject.transform.localPosition = location;
        }
    }
}