﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Times")]
    [SerializeField] float timeToStartGame = 15f;
    [SerializeField] float timeToMainMenu = 7.5f;

    [Header("Scene Number")]
    [SerializeField] int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Grabs the number of the current scene
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // If we are at the splash screen, do coroutine
        if (currentSceneIndex == 0)
        {
            StartCoroutine( SplashToStart() );
        }

        // If we are at the instructions screen, do coroutine
        if (currentSceneIndex == 2)
        {
            StartCoroutine( InstructionsToGame() );
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadInstructionsScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator SplashToStart()
    {
        yield return new WaitForSeconds(timeToMainMenu);
        LoadMainMenu();
    }

    IEnumerator InstructionsToGame()
    {
        yield return new WaitForSeconds(timeToStartGame);
        LoadGame();
    }
}

/*

SCENE NUMBERS:

Splash Screen   - 0
Main Menu       - 1
Instructions Screen  - 2
Game            - 3

*/