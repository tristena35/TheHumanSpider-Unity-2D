using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    [Header("Game Over Variables")]
    [SerializeField] bool isOver = false;

    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if( IsOver() )
        {
            sceneLoader.LoadGameOver();
        }
    }

    public bool IsOver()
    {
        return isOver;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if( collider.gameObject.tag == "HumanSpider" )
        {
            Debug.Log("Game Over!");
            isOver = true;
        }

    }
}
