# Scene Transitions and Screen Tint

## Description
This mechanic shows how to implement scene transitions and tint the screen.
Tinting the screen could be used to flash effects on the player, such as being damaged (red) or
being poisoned (green).

## Implementation
There are many types of transitions, but in this example a simple fade to black has been shown,
as well as a growing and shrinking black circle. Much of the steps are done in the Unity Editor.
1. Create an empty game object that will hold the animator.
2. Create a new canvas inside the new object and create an image inside the canvas. Set the UI Scale mode to "Scale with Screen Size."
3. To create a fade to black transition, leave the Souce Image blank. If you want to create a custom shape, such as a circle, drag the image/sprite to the field.
4. Scale the Image to the size of the screen by going to Rect Transform, holding Alt/Option and click the bottom right choice. Set the desired color.
5. Add a "Canvas Group" component to the image.
6. Open the Animation Window using the toolbar at the top of the screen (Window -> Animation)
7. With the Canvas selected, create a new animation that will serve as the first part of animation (ex. Fade *to* Black)
8. In the animation pane, click the record button, and create the animation with whatever effect you would like. For instance,
creating a Fade to Black animation over 1 second would entail setting the Alpha of the Canvas Group in step 5 to 0 at 0 seconds, and 1 at 1 second.
The Unity editor will automatically scale change the alpha at a consistent rate. Animations over time can be done to other properties of an object, such as the position or size. Ensure "Interactable" and "Block Raycasts" are not checked.
9. Create another animation in the dropdown menu at the left of the pane. Simply reverse the order of the first half of the animation to create a symmetrical animation.
10. Navigate to where the animations are saved. Uncheck the "Loop Time" property.
11. The Canvas created earlier should have an "Animator" component already added, with an Animator Controller created. If not, add/create them.
12. Open the Animator Controller. The "Entry" box should be pointing to the animation that plays when a level is opened. If not, right click the animation and "Set Layer as Default State"
13. Right click the first animation, select "Make Transition," and click on the second animation.
14. Under parameters, add a "Trigger" and name it.
15. Click the arrow/transition between the animations and add a condition with the trigger created in the previous step.
16. Disable "Has Exit Time" and "Transition Time" to 0.
17. Ensure the scenes are added in the build settings and in the correct order
18. Add the following script to the object created in step 1:

        using UnityEngine;
        using UnityEngine.SceneManagement;
        using System.Collections;

        public class LevelLoader : MonoBehaviour
        {

            public Animator transition;
            public float transitionTime = 1;

            void Update()
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    LoadNextLevel();
                }
            }

            public void LoadNextLevel()
            {
                StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }

            IEnumerator LoadLevel(int levelIndex)
            {
                transition.SetTrigger("Start");

                yield return new WaitForSeconds(transitionTime);

                SceneManager.LoadScene(levelIndex);
            }
        }

19. Drag the entire object created in step 1 to the assets to make it a prefab. This will allow you to easily add transitions to other scenes.
20. Open the prefab, and Reference the animator (canvas) in the inspector.

These tutorials by [Brackeys](https://www.youtube.com/watch?v=CE9VOZivb3I) and [Blackthornprod](https://www.youtube.com/watch?v=Qd2em_ts5vs) can be referenced
if the above tutorial is unclear or hard to follow over text.  

To implement screen tint,
1. Create a Canvas and create an image inside it. Scale it to the screen size via Rect Transform. Change the color to create the desired effect, such as red for 
being damaged or green for poisoned.
2. Add the following script to the image and drag the appropriate objects to the public fields in the inspector:

        using System.Collections;
        using UnityEngine;

        public class TintScreen : MonoBehaviour
        {
            public CanvasGroup tint;
            public float tintTime = 0.2f;
            public float opacity = 0.5f;

            void Update()
            {
                if (Input.GetMouseButton(0))
                {
                    Tint();
                }
            }

            public void Tint()
            {
                StartCoroutine(ShowColor(tint));
            }

            IEnumerator ShowColor(CanvasGroup tint)
            {
                tint.alpha = opacity;

                yield return new WaitForSeconds(tintTime);

                tint.alpha = 0;

            }
        }
