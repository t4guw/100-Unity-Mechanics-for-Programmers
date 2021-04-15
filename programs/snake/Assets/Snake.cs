using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private Vector2Int direc;
    private Vector2Int gridPos;
    public float maxMoveTimer = 0.5f;
    private float moveTimer = 0;
    private LevelGrid levelGrid;
    private int snakeSize;
    private List<Vector2Int> snakePositionList;
    private List<GameObject> snakeBodyList;
    private Sprite snakeBody;

    public void Setup(LevelGrid levelGrid, Sprite snakeBody)
    {
        this.levelGrid = levelGrid;
        this.snakeBody = snakeBody;
    }

    private void Awake()
    {
        gridPos = new Vector2Int(0, 0);
        direc = new Vector2Int(1, 0);

        snakePositionList = new List<Vector2Int>();
        snakeBodyList = new List<GameObject>();
    }

    private void Update()
    {
        UserInput();
        AutoMove();

    }

    private void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (direc.y != -1)
            {
                direc = new Vector2Int(0, 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (direc.y != 1)
            {
                direc = new Vector2Int(0, -1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (direc.x != 1)
            {
                direc = new Vector2Int(-1, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (direc.x != -1)
            {
                direc = new Vector2Int(1, 0);
            }
        }
    }

    private void AutoMove()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= maxMoveTimer)
        {
            snakePositionList.Insert(0, gridPos);
            if(gridPos.x > levelGrid.getWidth())
            {
                gridPos.x = -levelGrid.getWidth();
            }
            else if (gridPos.x < -levelGrid.getWidth())
            {
                gridPos.x = levelGrid.getWidth();
            }
            else if (gridPos.y > levelGrid.getHeight())
            {
                gridPos.y = -levelGrid.getHeight();
            }
            else if (gridPos.y < -levelGrid.getHeight())
            {
                gridPos.y = levelGrid.getHeight();
            } else { gridPos += direc; }
            
            moveTimer = 0;
            
            bool ateFood = levelGrid.SnakeFood(gridPos);
            if (ateFood)
            {
                snakeSize++;
                CreateSnakeBody();
            }

            if (snakePositionList.Count >= snakeSize + 1)
            {
                snakePositionList.RemoveAt(snakePositionList.Count - 1);
            }

            foreach (GameObject gameObject in snakeBodyList)
            {
                Vector2Int snakeBodyPosition = new Vector2Int((int) gameObject.transform.position.x, (int) gameObject.transform.position.y);
                if (gridPos == snakeBodyPosition)
                {
                    Reset();
                }
            }

            transform.position = new Vector3(gridPos.x, gridPos.y);

            for(int i = 0; i < snakeBodyList.Count; i++)
            {
                Vector3 snakeBodyPosition = new Vector3(snakePositionList[i].x, snakePositionList[i].y);
                snakeBodyList[i].transform.position = snakeBodyPosition;
            }
        }
    }

    private void CreateSnakeBody()
    {
        GameObject snakeBodyObject = new GameObject("SnakeBody", typeof(SpriteRenderer));
        snakeBodyObject.GetComponent<SpriteRenderer>().sprite = snakeBody;
        snakeBodyObject.transform.localScale = new Vector3(2f, 2f);
        //snakeBodyObject.GetComponent<SpriteRenderer>().sortingOrder = -snakeBodyList.Count;
        snakeBodyList.Add(snakeBodyObject);
    }

    public Vector2Int GetPosition()
    {
        return gridPos;
    }

    public List<Vector2Int> GetPositionList()
    {
        List<Vector2Int> gridPosList = new List<Vector2Int>() { gridPos };
        gridPosList.AddRange(snakePositionList);
        return gridPosList;
    }

    private void Reset()
    {
        while (snakeBodyList.Count > 0)
        {
            GameObject gameObjectToRemove = snakeBodyList[0];
            snakeBodyList.Remove(gameObjectToRemove);
            Destroy(gameObjectToRemove);
        }

        gridPos = new Vector2Int(0, 0);
        direc = new Vector2Int(1, 0);
    }
}
