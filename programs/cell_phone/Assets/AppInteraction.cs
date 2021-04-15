using UnityEngine;
using UnityEngine.UI;

public class AppInteraction : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject inApps;
    public GameObject[] apps;
    GameObject currentApp;
    Text appNameText;

    void Start()
    {
        appNameText = GameObject.Find("AppName").GetComponent<Text>();
    }

    public void HomeButton()
    {
        if (currentApp != null)
        {
            currentApp.SetActive(false);
        }
        appNameText.text = "";
        homeScreen.SetActive(true);
        inApps.SetActive(false);
    }

    public void OpenApp(int appIndex)
    {
        homeScreen.SetActive(false);
        inApps.SetActive(true);
        currentApp = apps[appIndex];
        currentApp.SetActive(true);
    }
}
