using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class PauseWindow : MonoBehaviour
{
    private static PauseWindow instance;
    private void Awake()
    {
        instance = this;
        transform.Find("resumeButton").GetComponent<Button_UI>().ClickFunc = () => GameHandler.ResumeGame();
        transform.Find("resumeButton").GetComponent<Button_UI>().AddButtonSounds();
        transform.Find("mainMenuButton").GetComponent<Button_UI>().ClickFunc = () => SceneManager.LoadScene("MainMenu");
        transform.Find("mainMenuButton").GetComponent<Button_UI>().AddButtonSounds();

        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }

    public static void HideStatic()
    {
        instance.Hide();
    }
}
