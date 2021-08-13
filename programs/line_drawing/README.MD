# Line Drawing
## Description
This mechanic shows how to implement drawing lines with hitboxes.

## Implementation
1. Create an Empty Object (Name it Line) and attach the Line Renderer and Edge Collider 2D component.
2. In your Assets, create a new Material object and name it LineMaterial this doesn't need much changing but you're free to mess around with it to see what effects it applies to the line.
3. Drag the LineMaterial to the Materials Section Element 0 of Line Renderer on the Line object.
4. If you have a background (especially if it's a UI Panel) make sure to put the Line object in the highest layer that it needs to be visible ny adjusting the Order in Layer.
5. Drop down 'Positions' you can set X Index 1 to 5 to see what the line will look like when the player draws it.
The Width will determine the thickness of the line, you can also select the color with Color and the roundness of the edges with End Cap Vertices
6. Once you are satisfied with the Line object drag it onto your Assets to create a Line Prefab, you can then delete the Line object in the Scene.
7. Create a new script called LineDraw and set up these variables:
    public GameObject linePrefab;
    public GameObject currentLine;
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPositions;

Many of these won't need to be public later (aside from the linePrefab as we need to give it the Prefab within Unity.
Each time the user presses and releases the mouse, a line object will be made so we need to keep track of the current Line being drawn with currentLine
lineRenderer and edgeCollider are just holders to have easier access to those components when we need to call them and lastly fingerPositions keeps track of where the mouse goes for the Line to be drawn.
8. Within Update() create an if statement to check GetMouseButtonDown(0) (which checks if left click was pressed down) and within that statement call CreateLine()
9. After that if statement create another that checks GetMouseButton(0) (which checks if left click is still pressed) and within that if statement create a new Vector2 called tempPos and have it equal the mouse's position: Camera.main.ScreenToWorldPoint(Input.mousePosition)
10. Still inside the GetMouseButton if statement and after the tempPos, create another if statement to check the distance between tempPos and the last position within fingerPositions: tempPos, fingerPositions[fingerPositions.Count - 1]) > 0.1f
You can change 0.1f to whatever value you want. What we're doing here is setting a minimum distance for there to be a new position for the line, the larger the distance, the more jaggedy the line will look.
11. Within that if statement call UpdateLine(tempPos);
12. Create a new void method called CreateLine.
13. insantiate a new linePrefab with an zeroed Vector3 and Quaternion: Instantiate(linePrefab, Vector3.zero, Quaternion.identity) and assign it to currentLine
14. Assign lineRenderer to currentLine's LineRenderer and assign edgeCollider to currentLine's EdgeCollider2D
15. Clear the fingerPositions() as this is a new line and add the mouse position twice to the list:
fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
fingerPositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
We do this because we want the line to appear even if the user just clicks the mouse which in this case will cause the line to appear as a dot.
16. Next, set the position of the lineRenderer's index 0 and 1 with fingerPositions 0 and 1 respectively:
    lineRenderer.SetPosition(0, fingerPositions[0]);
    lineRenderer.SetPosition(1, fingerPositions[1]);
17. Then update the edgeCollider's points to the fingerPositions:
    edgeCollider.points = fingerPositions.ToArray();
18. Next create a void UpdateLine which takes in Vector2 newFingerPos
19. Within this method add newFingerPos to fingerPositions, increase lineRenderer's positionCount by 1, set the next position index to newFingerPos and update edgeCollider in the same way as in CreateLine:
    fingerPositions.Add(newFingerPos);
    lineRenderer.positionCount++;
    lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
    edgeCollider.points = fingerPositions.ToArray();
20. Now within Unity, add the script to a game object, if you have made any UI object you likely already have an EventSystem object where the LineDraw component will fit nicely, otherwise you could create an Empty Object and call it SystemManager or something and add it to that.
21. Make sure you drag Line to the LinePrefab in the component and you can hit play and test out the line drawing yourself.