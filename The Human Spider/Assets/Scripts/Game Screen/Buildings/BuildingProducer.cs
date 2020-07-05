using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingProducer : MonoBehaviour
{
    [Header("Building to be Produced")]
    [SerializeField] GameObject buildingPrefab;

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
    }
}
