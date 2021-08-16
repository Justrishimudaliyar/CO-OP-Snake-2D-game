using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;
    public static GameAssets Instance { get { return instance; } }
    
    public Sprite snakeHeadSprite;
    public Sprite foodSprite;
    public Sprite snakeBodySprite;
    public Sprite burnerSprite;
    public SoundAudioClip[] soundAudioClipArray;
    [Serializable]
    public class SoundAudioClip
    {
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    private void Awake()
    {
        instance = this;
    }
}
