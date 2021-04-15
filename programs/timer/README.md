# Timer

## Description
This mechanic shows how to implement a timer with a timer bar in Unity.

## Implementation
There are several steps that need to be done in the Unity Editor.

   1. Create a text object and attach the following script to it. 
   2. Create an empty object in the canvas.
   2. Create an Image UI Object to be the fill for the timer bar and put it as the child of the empty object.
   3. Resize the parent to the desired size.
   4. Go to the anchors for the fill object, hold ALT key and select the bottom right choice.
   5. Add a slider component to the parent object, disable interactable, change transition to "none", and navigation to "none".
   6. Drag the fill to the "Fill Rect" property.
   7. Change the fill color to the desired color.
   8. Drag the parent object to the slider variable in the Timer script.
   9. Add desired action to the else statement to trigger when the timer runs out.
    
    

    using UnityEngine;
    using UnityEngine.UI;

    public class Timer : MonoBehaviour
    {
        public Slider slider;
        float secRemaining = 90f;
        bool timerEnded = false;


        void Start()
        {
            slider.maxValue = secRemaining;
            slider.value = secRemaining - 1f;
        }

        void Update()
        {

            if (!timerEnded)
            {
                if (secRemaining > 1)
                {
                    secRemaining -= Time.deltaTime;
                    float minutes = Mathf.FloorToInt(secRemaining / 60);
                    float seconds = Mathf.FloorToInt(secRemaining % 60);
                    this.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);
                }
                else
                {
                    this.GetComponent<Text>().color = new Color(150f, 0f, 0f);
                }
            }
        }
    }