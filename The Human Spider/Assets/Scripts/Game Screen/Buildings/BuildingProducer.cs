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

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        ResetBuildingHeight();
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
