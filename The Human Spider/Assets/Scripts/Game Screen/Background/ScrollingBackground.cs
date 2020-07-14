using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{

    [Header("Background Attributes")]
    [SerializeField] float scrollSpeed;
    public Renderer backgroundRenderer;

    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        backgroundRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0f);
    }
}
