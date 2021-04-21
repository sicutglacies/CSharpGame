using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpanGridScript : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public int gridx;
    public int gridy;
    public float gridSpacingOffset = 1f;
    public Vector3 gridorigin = Vector3.zero;

    void Start()
    {
        SpawnGrid();
    }
    void SpawnGrid()
    {
        for (int x = 0; x < gridx; x++)
        {
            for (int y = 0; y < gridy; y++)
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, 0, y * gridSpacingOffset) + gridorigin;
                PickAndSpawn(spawnPosition, Quaternion.identity);
                void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
                {
                    int randomIndex = UnityEngine.Random.Range(0, itemsToPickFrom.Length);
                    GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
                }
            }
        }
    }
}
            
            
