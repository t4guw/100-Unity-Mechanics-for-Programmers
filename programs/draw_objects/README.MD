# Draw Objects
## Description
This mechanic shows how to implement drawing objects with hit boxes

## Implementation
1. Create a prefab of the object you want to draw, in our case we made a square with a box collider.
2. This implementation will follow a similar structure to Line Drawing
3. Create the following variables:
    public GameObject platformPrefab;
    private GameObject currentPlatform;
    private Transform _transform;
    private List<GameObject> platformList;
    private Vector3 startClick;

4. Within the Start() method, assign platformList to a new List<GameObject>()
5. Within the Update() method create 3 if statements, one for Input.GetMouseButtonDown(0), one for Input.GetMouseButton(0), and one for Input.GetKeyDown(KeyCode.Backspace)
6. For Input.GetMouseButtonDown(0) call CreatePlatform(), for Input.GetMouseButton(0) call UpdatePlatform(), and for Input.GetKeyDown(KeyCode.Backspace) call DeletePlatform()
7. Now create a void CreatePlatform() method.
8. Assign startClick to Camera.main.ScreenToWorldPoint(Input.mousePosition)
9. Instantiate a new platform with an zeroed Vector3 and Quaternion and assign it to currentPlatform: currentPlatform = Instantiate(platformPrefab, Vector3.zero, Quaternion.identity);
10. Assign _transform to the currentPlatform's transform and assign _transform.position to a new vector3 that uses startClick.x, startClick.y, and 1 for z
11. Lastly add the currentPlatform to the platformList.
12. Now make a void UpdatePlatform() method.
13. Grab the current mouse position again and assign it to a Vector3 tempClick
14. Create a float x and y and assign them to startClick.x - tempClick.x and startClick.y - tempClick.y respectively.
15. Assign _transform.localScale to a new Vector3 that takes x, y, and _transform.localScale.z.
16. Now the object will resize when we drag the mouse around, however due to how Transform is implemented, the object will be at the center of the original click and not really follow the mouse drag:
17. Create a new Vector3 called drag and assign it to Vector3.Lerp(startClick, tempClick, 0.5f), this creates a vector between the two vectors at the specified percentage.
18. Assign _transform.position to a new Vector3 that takes in drag.x, drag.y and _transform.position.z
19. Now, the object's position gets dynamically updated as the user drags around the mouse and the lower corner of the object will be where the mouse is.
20. Now create a void DeletePlatform() and add an if statement to make sure that platformList's size is greater than 0.
21. Within that if statement grab the last game object in the platformList and assign it to a temp gameObject variable, remove item at the end of platformList, and then Destroy the temp gameobject:
	    GameObject tempObj = platformList[platformList.Count - 1];
            platformList.RemoveAt(platformList.Count - 1);
            Destroy(tempObj);
This removes it from our game object list but also removes it from the game.
22. Now you can go back into Unity and assign this script to really any object but we suggest the EventSystem that is made when you create a UI object. Make sure to assign a prefab to be used and you can test this within Unity.