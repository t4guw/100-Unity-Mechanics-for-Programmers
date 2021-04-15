using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private LevelGrid levelGrid;
    public int gridW = 10;
    public int gridH = 10;
    public Sprite food;
    public Sprite snakeBody;
    [SerializeField] private Snake snake;

    // Start is called before the first frame update
    void Start()
    {
        levelGrid = new LevelGrid(gridW, gridH, food);
        snake.Setup(levelGrid, snakeBody);
        levelGrid.Setup(snake);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
