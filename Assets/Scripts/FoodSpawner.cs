using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public enum Food
    {
        food,
        deadFood,
    }

    public Food foodType;
    public Food getFood = Food.deadFood;
    private Vector2Int foodPosition;
    [SerializeField] private Snake snake;
    private int width;
    private int height;

    private void Awake()
    {
        width = 15;
        height = 15;
        foodType = Food.food;
    }

    private void Start()
    {
        StartCoroutine(FoodTimer());
    }

    public void SpawnFood()
    {
        do
        {
            foodPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        }
        while (snake.GetFullSnakeGridPositionList().IndexOf(foodPosition) != -1);

        if (snake.GetSnakeSize() > 1)
        {
            int select = Random.Range(0, 3);
            switch (select)
            {
                default:
                    GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;
                    foodType = Food.food;
                    break;
                case 0:
                    GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;
                    foodType = Food.food;
                    break;
                case 1:
                    GetComponent<SpriteRenderer>().sprite = GameAssets.instance.burnerSprite;
                    foodType = Food.deadFood;
                    break;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = GameAssets.instance.foodSprite;
            foodType = Food.food;
        }

        transform.position = new Vector3(foodPosition.x, foodPosition.y);
    }

    public bool EatFood(Vector2Int snakeGridPosition)
    {

        if (snakeGridPosition == foodPosition)
        {
            switch (foodType)
            {
                default:
                    Score.AddScore();
                    snake.deadFood = false;
                    break;
                case Food.food:
                    snake.deadFood = false;
                    Score.AddScore();
                    break;
                case Food.deadFood:
                    Score.SubtractScore();
                    snake.deadFood = true;
                    break;
            }

            SpawnFood();
            return true;
        }
        else return false;
    }

    public IEnumerator FoodTimer()
    {
        while (true)
        {
            SpawnFood();
            yield return new WaitForSeconds(4f);
        }
    }

}
