using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsStarted()
    {
        return isStarted;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        isStarted = true;

        StartCoroutine( StartKeepingScore() );
        
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        
    }

    IEnumerator StartKeepingScore()
    {
        yield return new WaitForSeconds(3f);
        
        scoreKeeper.SetStartTracking();
    }
}
