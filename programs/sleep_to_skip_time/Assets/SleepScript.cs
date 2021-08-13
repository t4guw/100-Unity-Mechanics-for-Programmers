using UnityEngine;

public class SleepScript : MonoBehaviour
{
    public GameObject promptSleep;
    public GameObject dropdowns;

    bool nearBed;

    void Start()
    {
        nearBed = false;
    }

    void Update()
    {
        if (nearBed && Input.GetKeyDown(KeyCode.E))
        {
            promptSleep.SetActive(false);
            dropdowns.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            promptSleep.SetActive(true);
            nearBed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            promptSleep.SetActive(false);
            dropdowns.SetActive(false);
            nearBed = false;
        }
    }
}
