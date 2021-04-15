# Volume Control and Mute Music

## Description
This mechanic shows how to implement changing music volume via a UI slider, and muting music via a UI button

## Implementation
There are several steps that need to be taken in the Unity Editor for this mechanic.
- For the volume slider: 
1. Create a UI slider that will be used to control the volume
2. Attach the following script to the slider:

        using UnityEngine;
        using UnityEngine.UI;

        public class VolumeController : MonoBehaviour
        {
            public AudioSource source;
            private Slider slider;

            private void Start()
            {
                slider = this.GetComponent<Slider>();   
            }

            private void Update()
            {
                source.volume = slider.value;
            }
        }
- For the mute button:
1. Create a new UI Button that will serve as the mute button.
2. Attach the following script to the button:

        using UnityEngine;
        using UnityEngine.UI;

        public class MuteMusic : MonoBehaviour
        {
            public AudioSource source;
            private Button button;

            private void Start()
            {
                button = this.GetComponent<Button>();
                source.mute = false;
                ChangeText();
            }

            public void Mute()
            {
                source.mute = !source.mute;
                ChangeText();
            }

            private void ChangeText()
            {
                if (source.mute)
                {
                    button.GetComponentInChildren<Text>().text = "Muted";

                }
                else
                {
                    button.GetComponentInChildren<Text>().text = "Unmuted";
                }
            }
        }
    The script will change the text inside the button, but an Image of a speaker can be used instead.

- Ensure an Audio Source has been attached to the Main Camera with a desired soundtrack. In the inspector for the slider and button, attach that audio source to the empty fields inside the above script components.


