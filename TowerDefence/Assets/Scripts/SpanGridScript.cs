using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates gaming area, 
///     TODO: generates random path
/// </summary>
public class SpanGridScript : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public int GridX;
    public int GridY;

    private Vector3 GridZeroPoint = Vector3.zero;
    private float GridSpacingOffset = 5;

    void Start()
    {
        SpawnGrid();
    }
    void SpawnGrid()
    {
        for (int x = 0; x < GridX; x++)
        { 
            for (int y = 0; y < GridY; y++)
            {
                var spawnPosition = new Vector3 (x * GridSpacingOffset, 0, y * GridSpacingOffset) + GridZeroPoint;
                PickAndSpawn(spawnPosition, Quaternion.identity);
            }
        }
    }
    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        var randomIndex = Random.Range(0, itemsToPickFrom.Length);
        var clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }
}        