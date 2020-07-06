using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    GameOverTrigger gameOverTrigger;

    // Start is called before the first frame update
    void Start()
    {
        gameOverTrigger = FindObjectOfType<GameOverTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
