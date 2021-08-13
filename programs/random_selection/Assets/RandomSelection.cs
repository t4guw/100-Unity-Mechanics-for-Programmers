using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomSelection : MonoBehaviour
{
    public AudioClip beep;
    public GameObject[] options;
    int optionSelected;
    float maxTime;
    float currentTime;
    float previousTimeCheck;
    float timeInterval;
    Color selectedColor;
    Color normalColor;

    void Start()
    {
        maxTime = 9f;
        currentTime = Random.Range(6f, maxTime + 1f);
        previousTimeCheck = currentTime;
        timeInterval = 0.01f;
        optionSelected = 0;
        selectedColor = new Color(219f, 219f, 0f);
        normalColor = new Color(255f, 255f, 255f);
        options[optionSelected].GetComponent<Image>().color = selectedColor;
    }

    void Update()
    {
        currentTime -= Time.smoothDeltaTime;
        if (previousTimeCheck - currentTime > timeInterval && currentTime > 0)
        {
            AudioSource.PlayClipAtPoint(beep, Vector3.zero);
            options[optionSelected].GetComponent<Image>().color = normalColor;
            previousTimeCheck = currentTime;
            if (optionSelected == options.Length - 1)
            {
                optionSelected = 0;
            }
            else
            {
                optionSelected++;
            }
            options[optionSelected].GetComponent<Image>().color = selectedColor;
            timeInterval += 0.01f;
        }
        else
        {
            //Implement desired effect with the selected option
        }
    }

    public void SelectAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
