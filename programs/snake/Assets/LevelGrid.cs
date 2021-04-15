using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid
{
    private Vector2Int foodPos;
    private int gridWidth;
    private int gridHeight;
    private GameObject food;
    private Sprite foodSprite;
    private Snake snake;

    public LevelGrid(int w, int h, Sprite sprite)
    {
        gridWidth = w - 1;
        gridHeight = h - 1;
        foodSprite = sprite;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
    }

    private void SpawnFood()
    {
        do
        {
            foodPos = new Vector2Int(Random.Range(-gridWidth, gridWidth), Random.Range(-gridHeight, gridHeight));
        } while (snake.GetPositionList().IndexOf(foodPos) != -1);
        food = new GameObject("Food", typeof(SpriteRenderer));
        food.GetComponent<SpriteRenderer>().sprite = foodSprite;
        food.transform.localScale = new Vector3(2f, 2f);
        food.transform.position = new Vector3(foodPos.x, foodPos.y);
    }

    public bool SnakeFood(Vector2Int snakePos)
    {
        if(snakePos == foodPos)
        {
            Object.Destroy(food);
            SpawnFood();
            return true;
        }
        return false;
    }

    public int getWidth()
    {
        return gridWidth;
    }
    public int getHeight()
    {
        return gridHeight;
    }
}
