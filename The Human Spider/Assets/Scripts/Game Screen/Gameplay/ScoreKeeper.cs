using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    float score;
    bool startTracking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( startTracking )
        {
            startTracking = false;
            StartCoroutine( ScoreTracking(1f) );
        }
        SetUpdatedScore();
    }

    private IEnumerator ScoreTracking(float waitTime) {
        while (true) 
        {
            yield return new WaitForSeconds(waitTime);
            score += 100;
        }
    }

    void SetUpdatedScore()
    {
        scoreText.text = score + "";
    }

    // Call from start trigger IEnumerator
    public void SetStartTracking()
    {
        startTracking = true;
    }
}
