using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = -5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
    }

    // TODO: Create method to put a rigidbody as well as collider when instantiated
}
