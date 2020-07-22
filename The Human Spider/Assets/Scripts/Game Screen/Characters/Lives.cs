using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [Header("All Lives")]
    [SerializeField] int numberOfLives = 3;
    [SerializeField] GameObject[] lives;

    Game game;
    ScoreKeeper scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLife()
    {
        if( numberOfLives == 1 )
        {
            scoreKeeper.SetGameIsOver();
            // Game Over
            game.EndGame();
        }
        else
        {
            lives[ numberOfLives - 1 ].SetActive(false);
            numberOfLives --;
        }
    }

    public int GetLives()
    {
        return numberOfLives;
    }
}
