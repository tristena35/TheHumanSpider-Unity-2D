using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{
    bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Debug.Log("Start Game!");
        isStarted = true;
    }
}
