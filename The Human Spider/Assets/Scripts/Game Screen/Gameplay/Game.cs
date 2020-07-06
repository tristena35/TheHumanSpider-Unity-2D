using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    StartTrigger startTrigger;

    // Start is called before the first frame update
    void Start()
    {
        startTrigger = FindObjectOfType<StartTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
