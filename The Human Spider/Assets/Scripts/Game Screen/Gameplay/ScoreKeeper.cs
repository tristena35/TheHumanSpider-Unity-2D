using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] float score;
    bool startTracking = false;
    [SerializeField] bool gameIsOver = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if( startTracking )
        {
            startTracking = false;
            StartCoroutine( ScoreTracking(1f) );
        }
    }

    // Call from StartTrigger IEnumerator
    public void SetStartTracking()
    {
        startTracking = true;
    }

    public void SetGameIsOver()
    {
        gameIsOver = true;
    }

    public float GetScore()
    {
        return score;
    }

    private IEnumerator ScoreTracking(float waitTime)
    {
        while ( !gameIsOver ) 
        {
            yield return new WaitForSeconds(waitTime);
            score += 100;
        }
    }
}