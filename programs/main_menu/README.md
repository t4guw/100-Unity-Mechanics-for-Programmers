# Main Menu

## Description
This mechanic shows how to implement a simple main menu in 2D

## Implementation
The steps to implement this mechanic are done in the editor.
1. Have a separate Main Menu Scene
2. Create a new panel game object under UI>Panel, name this "Backgrtound
3. Update the Panel Image to desired background image (adjust alpha to max to see image)
4. Create an Empty game object through "Create Empty", name this "MainMenu"
5. Create a new button game object under UI>Button within MainMenu name this "PlayButton"
6. Change the color to black and set it's alpha channel to 0 (so you do not see it)
7. Create a new text game object under UI>Text within PlayButton and change the text to "Play"
8. Make sure PlayButton and it's Text occupy the same space and size, the button's color will highlight the text next.
9. In PlayButton, set Normal Color to Black with 0 alpha, set Highlighted Color to Black with a small alpha, set Pressed Color to Black with a larger alpha.
10. Feel free to test out the level, when you hover over play, the area around it should darken, when pressed it should darken more.
11. Create a Copy of PlayButton within MainMenu and name it OptionsButton and update the text to Options
12. Create a Copy of MainMenu within Canvas and name it OptionsMenu, set it to disabled.
13. Under Assets, create a new C# Script and name it "MainMenu"
14. Within the MainMenu Script, remove the Start and Update methods and replace it with a public void PlayGame method.
15. Add "using UnityEngine.SceneManagement;" under line 3.
16. Add "SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);" 
17. Back in Unity, on PlayButton, add a new On Click action, for the object, drag the MainMenu OBJECT into it.
18. For function select MainMenu then PlayGame()
19. If you have another scene ready you can test the button's functionality, if not you can assign scene order in Build Settings by dragging and dropping your scene files in assets into scenes in build.
20. On OptionsButton add two new On Click actions, for the first, drag and drop the OptionsMenu Object into it and for function select GameObject>SetActive, check the box.
21. For the second action drag and drop the MainMenu OBJECT into it and for function select GameObject>SetActive, uncheck the box.
22. Under OptionsMenu update PlayButton to BackButton and change the text to be "Back".
23. Adjust the buttons so Options hangs above the back button.
24. For BackButton add two new On Click actions, for the first, drag and drop the OptionsMenu Object into it and for function select GameObject>SetActive, uncheck the box.
25. For the second action drag and drop the MainMenu OBJECT into it and for function select GameObject>SetActive, check the box.
26. You should now have a functioning barebones main menu that can load the next scene and navigate to an options menu.