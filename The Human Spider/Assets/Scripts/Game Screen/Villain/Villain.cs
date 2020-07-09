using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : MonoBehaviour
{
    [Header("Villain Traits")]
    [SerializeField] bool isMoving = true;
    [SerializeField] float moveSpeed = 5f;
    float timeToMove = 0.7f;

    [Header("Villain Projectile")]
    [SerializeField] GameObject projectile;
    Vector2 bombMoveSpeed = new Vector2( -5f, 0f );
    

    [Header("Villain Sounds")]
    [SerializeField] AudioClip helloMyDearSFX;
    float villainVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Play Yelling Audio Clip
        AudioSource.PlayClipAtPoint(helloMyDearSFX, Camera.main.transform.position, villainVolume);

        StartCoroutine( MoveForTwoSeconds() );
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

    IEnumerator MoveForTwoSeconds()
    {
        yield return new WaitForSeconds(timeToMove);

        // Stop moving
        isMoving = false;
        StartCoroutine( ThrowBombsContinuously() );
    }

    IEnumerator ThrowBombsContinuously()
    {
        yield return new WaitForSeconds(3f);

        ThrowBomb();
        StartCoroutine( ThrowBombsContinuously() );
    }
}