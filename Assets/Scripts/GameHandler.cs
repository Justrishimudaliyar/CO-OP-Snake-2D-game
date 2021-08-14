using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;


public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;
    private static int score;
    [SerializeField]
    private Snake snake;
    private LevelGrid levelGrid;

    private void Awake()
    {
        instance = this;
        InitializeStatic();
    }
    private void Start()
    {
        levelGrid = new LevelGrid(20, 20);
        snake.Setup(levelGrid);
        levelGrid.Setup(snake);

        CMDebug.ButtonUI(Vector2.zero, "Reload scene", () =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });
    }

    private static void InitializeStatic()
    {
        score = 0;
    }
    public static int GetScore()
    {
        return score;
    }

    public static void AddScore()
    {
        score += 100;    
    }
}
