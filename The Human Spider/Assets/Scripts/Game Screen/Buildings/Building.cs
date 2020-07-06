using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = -3f;

    StartTrigger startTrigger;

    // Start is called before the first frame update
    void Start()
    {
        startTrigger = FindObjectOfType<StartTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game has started, buildings start moving
        if ( startTrigger.IsStarted() )  
            transform.position += new Vector3( Time.deltaTime * moveSpeed, 0, 0) ;
    }

    // TODO: Create method to put a rigidbody as well as collider when instantiated
}
