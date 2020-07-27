using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    Lives lives;

    [Header("Stats")]
    public float endingScore;
    public int numberOfLives;

    [Header("Scene Number")]
    [SerializeField] int currentSceneIndex;

    private void Awake()
    {
        SetUpSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        InstantiateReferences();
    }

    void InstantiateReferences()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        lives = FindObjectOfType<Lives>();
    }

    // Update is called once per frame
    void Update()
    {
        // Grabs the number of the current scene
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Destroy it on main menu screen
        if( currentSceneIndex == 1 ) 
        {
            Destroy(gameObject);
        }
    }

    public void ResetGameStats()
    {
        endingScore = 0f;
        numberOfLives = 0;

        Debug.Log("Stats Reset");
    }

    public void GrabGameStats()
    {
        InstantiateReferences();

        endingScore = scoreKeeper.GetScore();
        numberOfLives = lives.GetLives();

        Debug.Log("Grab Stats Reset");
    }

    private void SetUpSingleton()
    {
        // If there is already a music object for the main theme, do not start a new one
        if(FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public float GetScore()
    {
        return endingScore;
    }
}