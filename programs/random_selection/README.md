# Random Selection

## Description
This mechanic shows how to randomly select one of many options with added visuals.

## Implementation
There are several steps that need to be done in the Unity Editor.

   1. Add UI Images for each option that is offered and add a UI text as a child.
   2. Change the text for each option to the desired choice.
   3. Attach the followin RandomSelection script to an empty Manager object.
   4. In the inspector, set the size of the options array to the amount of options and then drag each option to the array.
    

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
            Debug.Log(optionSelected);
            Debug.Log(options[optionSelected]);
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
