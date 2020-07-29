using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float currentTime = 0;
    public bool timerIsRunning = false;
    public float timeTillStart = 5f;
    public TextMeshProUGUI timeText;

    private void Start()
    {
        StartCoroutine( TimerToStart() );
    }

    void Update()
    {
        if (timerIsRunning)
        {
            currentTime += Time.deltaTime;
            DisplayTime(currentTime);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    void StartTimer()
    {
        timerIsRunning = true;
    }

    IEnumerator TimerToStart()
    {
        yield return new WaitForSeconds(timeTillStart);
        
        StartTimer();
    }
}