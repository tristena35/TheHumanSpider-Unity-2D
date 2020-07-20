using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [Header("All Lives")]
    [SerializeField] int numberOfLives = 3;
    [SerializeField] GameObject[] lives;

    Game game;

    // Start is called before the first frame update
    void Start()
    {
        game = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLife()
    {
        if( numberOfLives == 1 )
        {
            // Game Over
            game.EndGame();
        }
        else
        {
            lives[ numberOfLives - 1 ].SetActive(false);
            numberOfLives --;
        }
    }
}
