using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpider : MonoBehaviour
{
    Rigidbody2D rigidBody2D;

    [Header("Number Values")]
    [SerializeField] float jumpForce = 4f;
    [SerializeField] float initialJumpForceUp = 10f;
    [SerializeField] float initialJumpForceRight = 3f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        // Have the human spider jump onto the scene
        JumpOntoScene();
    }

    // Update is called once per frame
    void Update()
    {
        FixedUpdate();
    }

    void FixedUpdate()
    {
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
}
