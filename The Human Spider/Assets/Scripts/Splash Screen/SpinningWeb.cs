using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningWeb : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        RotateWeb();
    }

    void RotateWeb()
    {
        transform.Rotate( Vector3.forward * Time.deltaTime * 180 );
    }
}
