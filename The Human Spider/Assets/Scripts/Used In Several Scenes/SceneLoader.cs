using System.Collections;
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

        // If on loading screen, load game
        if (currentSceneIndex == 2)
        {
            StartCoroutine( LoadToGame() );
        }
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(3);
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

    IEnumerator LoadToGame()
    {
        yield return new WaitForSeconds(timeToStartGame);
        LoadGame();
    }
}
