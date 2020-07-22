using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [Header("Game Over Variables")]
    [SerializeField] bool isOver = false;
    
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
        if( IsOver() )
        {
            // Game Over
            game.EndGame();
        }
    }

    public bool IsOver()
    {
        return isOver;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if( collider.gameObject.tag == "HumanSpider" )
        {
            scoreKeeper.SetGameIsOver();
            isOver = true;
        }
    }
}
