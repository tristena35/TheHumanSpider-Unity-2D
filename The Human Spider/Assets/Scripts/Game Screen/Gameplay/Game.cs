﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    GameOverTrigger gameOverTrigger;
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        gameOverTrigger = FindObjectOfType<GameOverTrigger>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        sceneLoader.LoadGameOver();
    }
}
