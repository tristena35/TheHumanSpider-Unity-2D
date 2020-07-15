using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProducer : MonoBehaviour
{
    [Header("Building to be Produced")]
    [SerializeField] GameObject buildingPrefab;
    float verticalMovementDistance;

    [Header("Building Location")]
    [SerializeField] Vector3 startPos;

    [Header("Building Movement")]
    Vector2 buildingMoveSpeed = new Vector2( -5f, 0f );

    StartTrigger startTrigger;

    bool justStarted = true;

    // Start is called before the first frame update
    void Start()
    {
        startTrigger = FindObjectOfType<StartTrigger>();

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Send first building after intial trigger
        if ( startTrigger.IsStarted() && justStarted )
        {
            justStarted = false;
            CreateFirstBuilding();
        }
    }

    public void ProduceBuilding()
    {
        CreateBuilding();
    }

    // Only create button when building hits this trigger
    void CreateBuilding()
    {
        MoveNextBuilding();
        GameObject building = Instantiate(
                buildingPrefab, 
                transform.position, 
                Quaternion.identity) as GameObject;
        building.GetComponent<Rigidbody2D>().velocity = buildingMoveSpeed;
        ResetBuildingHeight();
    }

    void CreateFirstBuilding()
    {
        GameObject building = Instantiate(
                buildingPrefab, 
                transform.position, 
                Quaternion.identity) as GameObject;
        building.GetComponent<Rigidbody2D>().velocity = buildingMoveSpeed;
    }

    void MoveNextBuilding()
    {
        verticalMovementDistance = Random.Range( 0f, 4.0f );
        transform.position += new Vector3( 0f, verticalMovementDistance, 0f );
    }

    void ResetBuildingHeight()
    {
        transform.position = startPos;
    }
}
