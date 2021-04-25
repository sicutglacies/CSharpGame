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
    private HashSet<int> hashSet = new HashSet<int>()
    { 0, 1, 17, 18, 19, 20, 21, 37, 53, 69, 85, 101, 117, 133, 134,
    135, 136, 137, 138, 154, 170, 186, 202, 201, 217, 233, 234, 235,
    236, 237, 238, 239, 255};


    void Start()
    {
        SpawnGrid();
    }
    void SpawnGrid()
    {
        int index = 0;
        for (int x = 0; x < GridX; x++)
        { 
            for (int y = 0; y < GridY; y++)
            {      
                var spawnPosition = new Vector3 (x * GridSpacingOffset, 0, y * GridSpacingOffset) + GridZeroPoint;
                PickAndSpawn(spawnPosition, Quaternion.identity, index);
                index++;
            }
        }
    }
    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn, int index)
    {
        int id = 0;
        if (hashSet.Contains(index)) id = 1;
        var clone = Instantiate(itemsToPickFrom[id], positionToSpawn, rotationToSpawn);
    }
}        