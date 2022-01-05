using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;


public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;
    public static GameHandler Instance { get { return instance; } }
    [SerializeField] private Snake snake;
    [SerializeField] private FoodSpawner foodSpawn;
    //private LevelGrid levelGrid;
    private void Awake()
    {
        instance = this;
        Score.InitializeStatic();
        Time.timeScale = 1f;
        Score.TrySetNewHighscore(200);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePaused())
            {
                GameHandler.ResumeGame();
            }else
            {
                GameHandler.PauseGame();
            }
        }
    }
    public static void SnakeDied()
    {
        bool isNewHighScore = Score.TrySetNewHighscore();
        GameOverWindow.ShowStatic(isNewHighScore);
        ScoreWindow.HideStatic();
    }
    public static void ResumeGame()
    {
        PauseWindow.HideStatic();
        Time.timeScale = 1f;
    }
    public static void PauseGame()
    {
        PauseWindow.ShowStatic();
        Time.timeScale = 0f;
    }
    public static bool IsGamePaused()
    {
        return Time.timeScale == 0f;
    }
}
