using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        GameScene,
        Loading
    }

    private static Action loaderCallBackAction;
    public static void Load(Scene scene)
    {

        loaderCallBackAction = () => 
        { 
            SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(Scene.Loading.ToString()); 
    }   

    public static void LoaderCallback()
    {
        if(loaderCallBackAction != null)
        {
            loaderCallBackAction();
            loaderCallBackAction = null;
        }

    }
}
