using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaryJane : MonoBehaviour
{
    [Header("Mary Jane Audio")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] bool isMoving = true;
    float timeToMove = 0.7f;

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
    }
}
