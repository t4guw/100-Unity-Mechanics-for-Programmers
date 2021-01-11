# Change Scene With Key Press

## Description
This mechanic demonstrates changing scenes through key presses. We will change to a specific scene with a key press and navigate through all scenes through another.

## Implementation
1. Create a new C# Script and name it "ChangeScene"
2. Add "using UnityEngine.SceneManagement;" at the top of the file.
3. In this case we have 3 scenes to go through so we will have 3 specific keys to press to go to them.
4. Create 3 KeyCode objects, in this example do KeyCode.Alpha1 Alpha2 and Alpha3 (These are for 1 2 and 3) and name them scene1 scene2 and scene3.
5. Create another KeyCode object called navigate and have that be Keycode.N.
6. In the Update() Method, make an if statement that checks "Input.anyKey"
7. Within that if statement make an if statement to check "Input.GetKey(navigate)"
8. Within that if statement make another if statement to check "SceneManager.GetActiveScene().buildIndex >= 2" this is incase we've reached the last scene.
9. Within that if statement write "SceneManager.LoadScene(0);"
10. Make an else statement for instruction 8 that reads: "SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);"
11. After the if statement that checks Input.GetKey(navigate), do an else if statement that checks "Input.GetKey(scene1)"
12. For this if statement, it will do "SceneManager.LoadScene(0);"
13. Repeat 11 and 12 for the other scenes, adding 1 for each (I.E. GetKey(scene2) GetKey(scene3) LoadScene(1) LoadScene(2) respectively).
14. You can attach this script to anything in your Unity project, just make sure that each scene has this script in it.
15. Lastly make sure that you have your build Index set up correctly by going to build settings under File and only have the Scenes you want to use in the "Scenes In Build" window.