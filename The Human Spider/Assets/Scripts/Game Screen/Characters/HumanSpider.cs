using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpider : MonoBehaviour
{
    [Header("Human Spider Traits")]
    [SerializeField] int numberOfLives = 3;
    [SerializeField] float jumpForce = 3f;
    [SerializeField] float initialJumpForceUp = 10f;
    [SerializeField] float initialJumpForceRight = 3f;
    [SerializeField] float timeToMove = 3f;
    [SerializeField] float timeTillRun = 1.5f;
    [SerializeField] bool isLocked = true;
    Vector3 startPosition;
    Vector2 upwardForce;
    Rigidbody2D rigidBody2D;
    float moveSpeed = 2.7f;
    float rotationSpeed = 250f;
    
    [Header("Human Spider Audio")]
    [SerializeField] AudioClip hangOnMaryJaneSFX;
    float voiceVolume = 1f;

    [Header("Human Spider SFX / VFX")]
    [SerializeField] GameObject explosionVFX;
    [SerializeField] AudioClip bombExplodeSFX;
    float sfxVolume = 0.7f;

    [Header("Coordinate Boundaries")]
    public float xMax;

    Lives lives;

    // Start is called before the first frame update
    void Start()
    {
        SetUpBoundaries();

        lives = FindObjectOfType<Lives>();

        rigidBody2D = GetComponent<Rigidbody2D>();
        startPosition = new Vector3( transform.position.x, transform.position.y, 1 );
        upwardForce = new Vector2( 0f, jumpForce );

        // Have the human spider jump onto the scene
        StartCoroutine( InitialJump() );
    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
    }

    void FixedUpdate()
    {
        if( isLocked )
        {
            LockCharacter();
        }
        else
        {
            MoveHorizontally();
            Jump();
            Rotate();
        }
    }

    void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main;

        float halfWidth = 5f;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1,0,0)).x - halfWidth;
    }

    void MoveHorizontally()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, -100f, xMax);
        transform.position = new Vector3(newXPos, transform.position.y, 1);
    }

    void Jump()
    {
        if( Input.GetButtonDown("Jump") )
        {
            rigidBody2D.AddForce( upwardForce, ForceMode2D.Impulse );
        }
    }

    void Rotate()
    {
        var rotation = Input.GetAxis("RotateHumanSpider") * Time.deltaTime * rotationSpeed;
        transform.Rotate(Vector3.forward * rotation);
    }

    void JumpOntoScene()
    {
        rigidBody2D.AddForce( Vector2.up * initialJumpForceUp, ForceMode2D.Impulse );
        rigidBody2D.AddForce( Vector2.right * initialJumpForceRight, ForceMode2D.Impulse );        
    }

    void LockCharacter()
    {
        transform.position = startPosition;
        rigidBody2D.velocity = new Vector2( 0f, 0f );
    }

    IEnumerator InitialJump()
    {
        yield return new WaitForSeconds(timeToMove);
        
        isLocked = false;
        JumpOntoScene();
        // Play Yelling Audio Clip
        AudioSource.PlayClipAtPoint(hangOnMaryJaneSFX, Camera.main.transform.position, voiceVolume);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if( collider.gameObject.tag == "Projectile" )
        {
            Destroy(collider.gameObject);
            lives.LoseLife();
            /*
            GameObject explosion = Instantiate(
                    explosionVFX, 
                    new Vector3(transform.position.x, transform.position.y, 1), 
                    transform.rotation) as GameObject;
            */
            // Play Explode SFX Audio Clip
            AudioSource.PlayClipAtPoint(bombExplodeSFX, Camera.main.transform.position, sfxVolume);
        }
    }
}
