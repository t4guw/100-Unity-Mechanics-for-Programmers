# Snake
## Description
This mechanic shows how to a simple game of Snake

## Implementation
1. In our example we use two simple squares, one green for the snake and its body, and one red for food.
2. Create a new 2d Sprite called "Snake"
3. Create 3 C# Scripts, GameHander, LevelGrid, and Snake
4. In GameHandler for variables:
    private LevelGrid levelGrid;
    public int gridW = 10;
    public int gridH = 10;
    public Sprite food;
    public Sprite snakeBody;
    [SerializeField] private Snake snake;
gridW and gridH allow the user to tell the game handler the grid size and they default to 10, the Sprite food and snakeBody are for creating new food and snake body objects during gameplay. The Snake snake is so the levelGrid can intract with it.
5. Within the start method create a new LevelGrid for levelGrid that sends it the gridW, gridH, and food, call snake's Setup method; sending it levelGrid and snakeBody, and lastly call levelGrid's Setup method sending it snake (we will cover these methods in their respective scripts later)
6. Remove the : MonoBehavior bit on the public class LevelGrid as this won't be a monobehavior script
7. Within LevelGrid.cs create these variables:
    private Vector2Int foodPos;
    private int gridWidth;
    private int gridHeight;
    private GameObject food;
    private Sprite foodSprite;
    private Snake snake;
These variables will become clearer when we develop the methods
8. Create the constructor for LevelGrid that take in: int w, int h, Sprite sprite. (in our case we do w-1 and h-1 as it looks a bit weird when the snake or food are occupying the edges of the grid as they'll be cut off.)
9. Within the constructor assign gridWith to w, gridHeight to h, and foodSprite to sprite.
10. Create a public void Setup that takes in Snake snake
11. Within Setup, assign this.snake to snake, and call SpawnFood() (this method is next)
12. Create a private void SpawnFood()
13. Whenever we spawn a food object, we need to make sure that it does not spawn where the snake or it's body is already occupied:
do
        {
            foodPos = new Vector2Int(Random.Range(-gridWidth, gridWidth), Random.Range(-gridHeight, gridHeight));
        } while (snake.GetPositionList().IndexOf(foodPos) != -1);
This creates a new potential food position within the grid until that position does not occupy any of the snake's positions.
14. Now that we have a spawning location we can create the object:
        food = new GameObject("Food", typeof(SpriteRenderer));
        food.GetComponent<SpriteRenderer>().sprite = foodSprite;
        food.transform.localScale = new Vector3(2f, 2f);
        food.transform.position = new Vector3(foodPos.x, foodPos.y);
We scale the sprite in this case to match the size of the snake, this isn't required.
15. Create a public bool SnakeFood method that takes in a Vector2Int snakePos
16. Within SnakeFood check if snakePos is the same as foodPos, if it is, destroy the food object, call SpawnFood(), and return true. outside the if statement return false.
17. Make a public int getWidth() and public int getHeight() that return gridWidth and gridHeight respectively.
18. Within Snake.cs create these variables:
    private Vector2Int direc;
    private Vector2Int gridPos;
    public float maxMoveTimer = 0.5f;
    private float moveTimer = 0;
    private LevelGrid levelGrid;
    private int snakeSize;
    private List<Vector2Int> snakePositionList;
    private List<GameObject> snakeBodyList;
    private Sprite snakeBody;
Again these will become clearer as we make the methods, but maxMoveTimer is how often the snake will move, 1f being 1 second.
19. Create a public void Setup that takes in LevelGrid levelGrid and Sprite snakeBody.
20. Within Setup, assign this.levelGrid to levelGrid and this.snakeBody to snakeBody.
21. Create a private void Awake() method
22. Within Awake() set gridPos equal to a new Vector2Int of (0,0), this will be the snake's starting position in the grid, and set direc to a new Vector2Int of (1,0), this will be the starting movement direction the snake. Instantiate snakePositionList as a new List<Vector2Int>() and snakeBodyList as a new List<GameObject>().
23. Within Update() call UserInput() and AutoMove()
24. Create private void UserInput().
25. Within UserInput we want to check if the user has pressed WASD or Arrow keys and set the move direction appropriately, however, like in the Original Snake, you can't move back onto yourself:
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (direc.y != -1)
            {
                direc = new Vector2Int(0, 1);
            }
        }
Do this for every input, obviously adjusting the KeyCodes, direction check, and Vector2Int (see script if confused).
26. Create a private void AutoMove()
27. In AutoMove, add Time.deltaTime to moveTimer, then create an if statement to check if moveTimer is greater than maxMoveTimer, if so we know it's time to move the snake.
28. Within that if statement insert the current gridPos into the snakePositionList at spot 0: snakePositionList.Insert(0, gridPos);
29. Next (still inside if statement) check if the gridPos x and y exceed the bounds of the grid like so: if(gridPos.x > levelGrid.getWidth()) if they do, reset the gridPos to be at the opposite side of the grid like so: gridPos.x = -levelGrid.getWidth(); make sure to do this for each bound (left side, right side, up side, down side, see script if confused)
30. Next (still inside moveTimer >= maxMoveTimer if statement) set moveTimer to 0 and create a bool ateFood and set it to: levelGrid.SnakeFood(gridPos); we need to know if the snake ate a food block so we can increase it's size.
31. (still inside moveTimer >= maxMoveTimer if statement) Create a if statement to check ateFood and inside it increase snakeSize by 1 and call CreateSnakeBody();
32. Next (still inside moveTimer >= maxMoveTimer if statement) Create an if statement to check if the snakePositionList size is equal or greater than the snakeSize + 1, if so, remove the last snakePosition: snakePositionList.RemoveAt(snakePositionList.Count - 1);
33. Next (still inside moveTimer >= maxMoveTimer if statement) Create a foreach GameObject gameObject in snakeBodyList, within this create a new Vector2Int called snakeBodyPosition that takes in gameObject.transform.x and y (make sure to cast as int) and make an if statement to check if gridPos equals snakeBodyPosition, within this if statement is our fail state so call Reset()
34. Next (still inside moveTimer >= maxMoveTimer if statement) Set transform position to a new Vector3 that takes in gridPos x and y: transform.position = new Vector3(gridPos.x, gridPos.y); this will update the snake's head's position.
35. Next (still inside moveTimer >= maxMoveTimer if statement) create a for loop for i < snakeBodyList.Count and within that create a new Vector3 called snakeBodyPosition and have it take in the x and y of snakePositionList[i], then set the transform's position of snakeBodyList[i] to the new vector. This will update each snake body part's position.
36. Now create a private void CreateSnakeBody()
37. Within CreateSnakeBody create a new GameObject called SnakeBody:
	GameObject snakeBodyObject = new GameObject("SnakeBody", typeof(SpriteRenderer));
        snakeBodyObject.GetComponent<SpriteRenderer>().sprite = snakeBody;
        snakeBodyObject.transform.localScale = new Vector3(2f, 2f);
        //snakeBodyObject.GetComponent<SpriteRenderer>().sortingOrder = -snakeBodyList.Count;
        snakeBodyList.Add(snakeBodyObject);
You may need the commented out section as that will make sure that large sprites stay behind each other but you will need to make sure nothing else will get in the middle of the snake's sortingOrder
38. Next create a public Vector2Int GetPosition() that returns gridPos
39. Next create a public GetPositionList() that returns a List<Vector2Int>
40. Within that method create a new List<Vector2Int> called gridPosList and AddRange the snakePositionList and return that: 
        List<Vector2Int> gridPosList = new List<Vector2Int>() { gridPos };
        gridPosList.AddRange(snakePositionList);
        return gridPosList;
41. Next create a private void Reset()
42. Within that method make a while loop that continues while snakeBodyList's size is greater than 0 and within that destroy the snakeBodyList[0] object like so:
GameObject gameObjectToRemove = snakeBodyList[0];
        snakeBodyList.Remove(gameObjectToRemove);
        Destroy(gameObjectToRemove);
43. Lastly we need to reset the snake's position and direction so:
        gridPos = new Vector2Int(0, 0);
        direc = new Vector2Int(1, 0);
44. Back in Unity add the Snake script to the Snake object, add the Game Handler to the EventSystem and make sure to assign the Food sprite, Snake Body sprite, and the snake object and now you're snake game is ready.