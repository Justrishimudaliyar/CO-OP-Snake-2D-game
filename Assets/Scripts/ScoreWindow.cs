using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScoreWindow : MonoBehaviour
{

    private static ScoreWindow instance;
    private TextMeshProUGUI scoreText;
    private void Awake()
    {
        instance = this;
        scoreText = transform.Find("scoreText").GetComponent<TextMeshProUGUI>();

        Score.OnHighscoreChanged += Score_OnHighScoreChanged;
        UpdateHighscore();
    }

    private void Score_OnHighScoreChanged(object sender, EventArgs e)
    {
        UpdateHighscore();
    }
    

    private void Update()
    {
        scoreText.text = Score.GetScore().ToString();
    }
    private void UpdateHighscore()
    {
        int highscore = Score.GetHighscore();
        transform.Find("highScoreText").GetComponent<TextMeshProUGUI>().text = "Highscore to beat\n" + highscore.ToString();
    }

    public static void HideStatic()
    {
        instance.gameObject.SetActive(false);
    }
}
