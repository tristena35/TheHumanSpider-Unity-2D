using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaryJane : MonoBehaviour
{
    float timeToMove = 1f;

    float moveSpeed = 5f;

    bool isMoving = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine( MoveForTwoSeconds() );
    }

    // Update is called once per frame
    void Update()
    {
        if( isMoving )
            transform.position += new Vector3( Time.deltaTime * moveSpeed, Time.deltaTime * moveSpeed, 0);
    }

    IEnumerator MoveForTwoSeconds()
    {
        yield return new WaitForSeconds(timeToMove);
        isMoving = false;
        Debug.Log("Here");
    }
}
