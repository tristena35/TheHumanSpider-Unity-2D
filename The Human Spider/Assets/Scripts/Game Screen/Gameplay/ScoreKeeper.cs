using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

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
            ScoreTracking();
        }
    }

    // Every second that 
    void ScoreTracking()
    {

    }

    // Call from start trigger IEnumerator
    public void SetStartTracking()
    {
        startTracking = true;
    }
}
