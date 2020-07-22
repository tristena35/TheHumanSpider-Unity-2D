using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] int currentSceneIndex;

    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        SetUpSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
    }

    private void FixedUpdate()
    {
        // Grabs the number of the current scene
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Destroy it on main menu
        if( currentSceneIndex == 1 ) 
        {
            Destroy(gameObject);
        }

        if( currentSceneIndex == 4 ) 
        {
            scoreKeeper.SetGameIsOver();
        }
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
}
