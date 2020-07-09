# Loading Bar and Screen

## Description
This mechanic will show how to implement a loading screen that will include a loading bar.

## Implementation
There are several steps that need to be taken in the Unity Editor.
1. Ensure that the scenes are attached and in the correct order in the build settings.
2. Create an Empty GameObject, and attach a new script that will be used to control the loading screen.
3. Create a new UI panel with a slider UI object as a child. Set the panel to non-active (the checkmark to the left of the object name).
4. In the slider, disable "Interactable", change "Transition" to "None", "Navigation" to "None", and delete the "Handle Slide Area" from the hierarchy.
5. Scale up the slider to the desired size. Scale the "Fill Area" under the slider (from the hierarchy) to fill up the entire slider.
6. Under the GameObject created in step 2, drag and drop the loading scren panel to the "Loading Screen" variable, and the slider to the "slider" variable.

    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class LevelLoader : MonoBehaviour
    {
        public GameObject loadingScreen;
        public Slider slider;

        public void LoadLevel(int sceneIndex)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));

        }

        IEnumerator LoadAsynchronously (int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

            loadingScreen.SetActive(true);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                slider.value = progress;

                yield return null;
            }
        }
    }
