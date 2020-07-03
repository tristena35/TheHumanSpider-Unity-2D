using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProducer : MonoBehaviour
{
    [Header("Building to be Produced")]
    [SerializeField] GameObject buildingPrefab;

    float moveSpeed = -5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProduceBuilding()
    {
        CreateBuilding();
    }

    void CreateBuilding()
    {
        GameObject building = Instantiate(
                buildingPrefab, 
                transform.position, 
                Quaternion.identity) as GameObject;
        //building.GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0f);
    }
}
