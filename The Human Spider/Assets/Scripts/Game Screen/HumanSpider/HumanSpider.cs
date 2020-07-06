using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpider : MonoBehaviour
{
    Rigidbody2D rigidBody2D;

    [Header("Number Values")]
    [SerializeField] float jumpForce = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
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
}
