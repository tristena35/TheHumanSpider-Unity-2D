using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : MonoBehaviour
{
    [Header("Villain Traits")]
    [SerializeField] bool isMoving = true;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float moveVerticalSpeed = -2f;
    float threeSeconds = 3f;
    float timeToMove = 1f;
    float timeToMoveVertically = 2f;
    float timeInBetweenQuotes = 12f;

    [Header("Villain Projectile")]
    [SerializeField] GameObject projectile;
    Vector2 bombMoveSpeed = new Vector2( -5f, 0f );
    

    [Header("Villain Sounds")]
    [SerializeField] AudioClip helloMyDearSFX;
    float villainVolume = 1f;
    // 9 quotes
    [SerializeField] AudioClip[] goblinInGameQuotes;
    int quoteNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Play Yelling Audio Clip
        AudioSource.PlayClipAtPoint(helloMyDearSFX, Camera.main.transform.position, villainVolume);

        StartCoroutine( MoveForTwoSeconds() );
        StartCoroutine( SayQuotes() );
    }

    // Update is called once per frame
    void Update()
    {
        if( isMoving )
            transform.position += new Vector3( Time.deltaTime * moveSpeed, Time.deltaTime * moveSpeed, 0);
    }

    void ThrowBomb()
    {
        GameObject bomb = Instantiate(
                projectile,
                transform.position,
                Quaternion.identity) as GameObject;
        bomb.GetComponent<Rigidbody2D>().velocity = bombMoveSpeed;
    }

    // Called at start to fly up
    IEnumerator MoveForTwoSeconds()
    {
        yield return new WaitForSeconds(timeToMove);

        // Stop moving
        isMoving = false;
        StartCoroutine( ThrowBombsContinuously() );
        StartCoroutine( WaitToMoveVertically() );
    }

    // Throwing bombs
    IEnumerator ThrowBombsContinuously()
    {
        yield return new WaitForSeconds(threeSeconds);

        ThrowBomb();
        StartCoroutine( ThrowBombsContinuously() );
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

    // Every 12 seconds, says new quote
    IEnumerator SayQuotes()
    {
        yield return new WaitForSeconds(timeInBetweenQuotes);

        // Play Quote Audio Clip
        AudioClip quote = goblinInGameQuotes[ quoteNumber % 9];
        quoteNumber ++;
        AudioSource.PlayClipAtPoint(quote, Camera.main.transform.position, villainVolume);

        StartCoroutine( SayQuotes() );
    }
}