using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaryJane : MonoBehaviour
{
    [Header("Villain Traits")]
    [SerializeField] bool isMoving = true;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveVerticalSpeed = -2f;
    float threeSeconds = 3f;
    float timeToMove = 1f;
    float timeToMoveVertically = 2f;

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
        StartCoroutine( WaitToMoveVertically() );
    }
    // Start Vertical Movement after 3 seconds when stops intial fly
    IEnumerator WaitToMoveVertically()
    {
        yield return new WaitForSeconds(threeSeconds);

        StartCoroutine( VerticalMovement() );
    }

    // In game vertical movement
    IEnumerator VerticalMovement()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2( 0f, moveVerticalSpeed );
  
        yield return new WaitForSeconds(timeToMoveVertically);
        
        moveVerticalSpeed *= -1;
        StartCoroutine( VerticalMovement() );
    }
}
