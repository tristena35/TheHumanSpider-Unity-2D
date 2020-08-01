using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI endTimeText;

    GameStats gameStats;

    // Start is called before the first frame update
    void Start()
    {
        gameStats = FindObjectOfType<GameStats>();

        GrabGameTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GrabGameTime()
    {
        float timeGrabbed = gameStats.GetTime();
        DisplayTime(timeGrabbed);
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        endTimeText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }
}
