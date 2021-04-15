# Pause Game

## Description
This mechanic shows how to pause the game and show a pause menu. The pause menu features a resume button that
the user can click on to resume the game.

## Implementation
There are several steps in the Unity Editor that need to be completed:
1. Create a UI "Panel" that will serve as the pause menu.
2. Change the color of the panel to a transparent black/dark gray, and "source image" from background to none.
2. Create a button as a child of the panel that will be the resume button. Change the text of the button to "Resume", increase font size, and change color of text to white. You can add a "Shadow" component to add depth to the text.
3. Change the color of the "Image (Script)" component to black. 
4. Under the "Button (Script)" component, change the normal color Alpha to 0, "Highlighted Color" Alpha to 100, "Pressed Color" to 150, "Navigation" to none. Alpha values can be changed as desired.
5. Attach the following script to the *Canvas* and drag and drop the Panel created in step 1 to the empty field in the inspector:

        using UnityEngine;

        public class PauseMenu : MonoBehaviour
        {
            public static bool isPaused = false;

            public GameObject pauseMenuUI;

            void Update()
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (isPaused)
                    {
                        Resume();
                    } else
                    {
                        Pause();
                    }
                }
            }

            public void Resume()
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
            }

            private void Pause()
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
            }
        }
6. Select the Resume Button in the hierarchy, and in the inspector, add an OnClick() action using the "+" button.
7. Drag and drop the "Canvas" to the empty field. In the drop down to the right, select PauseMenu -> Resume().
8. Disable the Panel created in step 1 (check mark to the left of the object name in the inspector).
