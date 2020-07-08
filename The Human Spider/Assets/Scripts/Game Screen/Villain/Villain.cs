﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villain : MonoBehaviour
{
    float timeToMove = 1f;

    float moveSpeed = 5f;

    bool isMoving = true;

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

    IEnumerator MoveForTwoSeconds()
    {
        yield return new WaitForSeconds(timeToMove);
        isMoving = false;
        Debug.Log("Here");
    }
}