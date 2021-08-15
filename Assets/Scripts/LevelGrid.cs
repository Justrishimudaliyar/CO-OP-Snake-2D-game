using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    private Vector2Int foodGridPosition;
    private Vector2Int burnerGridPosition;
    private GameObject foodGameObject;
    private GameObject burnerGameObject;
    private int width;
    private int height;
    private Snake snake;
    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
    
    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
        SpawnBurner();
    }
    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } 
        while (snake.GetFullSnakeGridPositionList().IndexOf(foodGridPosition) != -1);

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    private void SpawnBurner()
    {
        do
        {
            burnerGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        }
        while (snake.GetFullSnakeGridPositionList().IndexOf(burnerGridPosition) != -1);

        burnerGameObject = new GameObject("Burner", typeof(SpriteRenderer));
        burnerGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.burnerSprite;
        burnerGameObject.transform.position = new Vector3(burnerGridPosition.x, burnerGridPosition.y);
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    { 
        if(snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            Score.AddScore();
            return true;
        }
        else
        { 
            return false;
        }
    }

    public bool TrySnakeEatBurner(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == burnerGridPosition)
        {
            Object.Destroy(burnerGameObject);
            SpawnBurner();
            Score.SubtractScore();
            return true;
        }
        else
        {
            return false;
        }
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        if(gridPosition.x < 0)
        {
            gridPosition.x = width - 1;
        }
        if (gridPosition.x > width - 1)
        {
            gridPosition.x = 0;
        }
        if (gridPosition.y < 0)
        {
            gridPosition.y = height - 1;
        }
        if (gridPosition.y > height - 1)
        {
            gridPosition.y = 0;
        }
        return gridPosition;
    }
}
