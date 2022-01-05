using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameOverWindow : MonoBehaviour
{

    private static GameOverWindow instance;
    private void Awake()
    {
        instance = this;
        transform.Find("retryButton").GetComponent<Button_UI>().ClickFunc = () =>
        {
            Loader.Load(Loader.Scene.GameScene);
        };
        Hide();
    }

    private void Show(bool isNewHighScore)
    {
        gameObject.SetActive(true);
        transform.Find("newHighScore").gameObject.SetActive(isNewHighScore);
        transform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = "CURRENT SCORE: " + Score.GetScore().ToString();
        transform.Find("highScoreText").GetComponent<TextMeshProUGUI>().text = "HIGHSCORE: " + Score.GetHighscore();
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic(bool isNewHighScore)
    {

        instance.Show(isNewHighScore);
    }
}
