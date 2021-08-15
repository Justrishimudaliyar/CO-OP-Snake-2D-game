using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class MainMenuWindow : MonoBehaviour
{

    private enum Sub
    {
        Main,
        HowToPlay
    }
    private void Awake()
    {
        transform.Find("howToPlaySubMenu").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.Find("mainSubMenu").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.Find("mainSubMenu").transform.Find("playButton").GetComponent<Button_UI>().ClickFunc = () => Loader.Load(Loader.Scene.GameScene);
        transform.Find("mainSubMenu").transform.Find("playButton").GetComponent<Button_UI>().AddButtonSounds();
        transform.Find("mainSubMenu").transform.Find("quitButton").GetComponent<Button_UI>().ClickFunc = () => Application.Quit();
        transform.Find("mainSubMenu").transform.Find("quitButton").GetComponent<Button_UI>().AddButtonSounds();
        transform.Find("mainSubMenu").transform.Find("howToPlayButton").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.HowToPlay);
        transform.Find("mainSubMenu").transform.Find("howToPlayButton").GetComponent<Button_UI>().AddButtonSounds();
        transform.Find("howToPlaySubMenu").transform.Find("backButton").GetComponent<Button_UI>().ClickFunc = () => ShowSub(Sub.Main);
        transform.Find("howToPlaySubMenu").transform.Find("backButton").GetComponent<Button_UI>().AddButtonSounds();
        ShowSub(Sub.Main);
    }

    private void ShowSub (Sub sub)
    {
        transform.Find("mainSubMenu").gameObject.SetActive(false);
        transform.Find("howToPlaySubMenu").gameObject.SetActive(false);

        switch (sub)
        {
            case Sub.Main:
                transform.Find("mainSubMenu").gameObject.SetActive(true);
                break;
            case Sub.HowToPlay:
                transform.Find("howToPlaySubMenu").gameObject.SetActive(true);
                break;
        }
    }
}
