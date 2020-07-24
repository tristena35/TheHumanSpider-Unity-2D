using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endScoreText;

    GameStats gameStats;

    // Start is called before the first frame update
    void Start()
    {
        gameStats = FindObjectOfType<GameStats>();

        GrabGameScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GrabGameScore()
    {
        endScoreText.text = gameStats.GetScore() + "";
    }
}
