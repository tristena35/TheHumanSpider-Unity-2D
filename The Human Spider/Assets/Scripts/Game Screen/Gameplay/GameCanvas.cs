using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    float gameScore;

    ScoreKeeper scoreKeeper;

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
        SetUpdatedScore();
    }

    void SetUpdatedScore()
    {
        gameScore = scoreKeeper.GetScore();
        scoreText.text = gameScore + "";
    }
}