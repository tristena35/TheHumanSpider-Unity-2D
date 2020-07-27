using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    GameStats gameStats;
    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        gameStats = FindObjectOfType<GameStats>();
        sceneLoader = FindObjectOfType<SceneLoader>();

        // Reset Stats at the start of every game
        gameStats.ResetGameStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        gameStats.GrabGameStats();

        sceneLoader.LoadGameOver();
    }
}