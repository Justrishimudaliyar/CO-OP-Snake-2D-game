using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PauseWindow : MonoBehaviour
{
    private static PauseWindow instance;
    private void Awake()
    {
        instance = this;
        transform.Find("resumeButton").GetComponent<Button_UI>().ClickFunc = () => GameHandler.ResumeGame();
        transform.Find("mainMenuButton").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.MainMenu);

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

    public static void ShowStatic() => instance.Show();

    public static void HideStatic()
    {
        instance.Hide();
    }
}
