using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [Header("Game Over Variables")]
    [SerializeField] bool isOver = false;
    Game game;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        if( IsOver() )
        {
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
            isOver = true;
        }
    }
}
