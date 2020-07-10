using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpider : MonoBehaviour
{
    [Header("Human Spider Traits")]
    [SerializeField] float jumpForce = 3f;
    [SerializeField] float initialJumpForceUp = 10f;
    [SerializeField] float initialJumpForceRight = 3f;
    [SerializeField] float timeToMove = 3f;
    Vector3 startPosition;
    [SerializeField] bool isLocked = true;
    Rigidbody2D rigidBody2D;
    
    [Header("Human Spider Audio")]
    [SerializeField] AudioClip hangOnMaryJaneSFX;
    float voiceVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        startPosition = new Vector3( transform.position.x, transform.position.y, 1 );

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
            LockCharacter();
        Jump();
    }

    void Jump()
    {
        if( Input.GetButtonDown("Jump") )
        {
            rigidBody2D.AddForce( transform.up * jumpForce, ForceMode2D.Impulse );
        }
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
}
