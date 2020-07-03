using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTrigger : MonoBehaviour
{
    BuildingProducer buildingProducer;

    void Start()
    {
        buildingProducer = FindObjectOfType<BuildingProducer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Building Trigger");
        buildingProducer.ProduceBuilding();
    }
}

