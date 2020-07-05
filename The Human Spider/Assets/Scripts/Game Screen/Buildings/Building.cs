using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed = -3f;

    float timeTillDestroy = 8f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this != null)  
            transform.position += new Vector3(Time.deltaTime * moveSpeed, 0, 0);
    }

    IEnumerator WaitThenDestroy()
    {
        yield return new WaitForSeconds(timeTillDestroy);
        Destroy(gameObject);
    }

    // TODO: Create method to put a rigidbody as well as collider when instantiated
}
