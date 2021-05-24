using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

/// <summary>
/// Creates gaming area, 
///     TODO: generates random path
/// </summary>
public class SpanGridScript : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public GameObject[] wayPointers = new GameObject[9];
    public GameObject shar;
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
        var wayPointerIndexes = CreateWayPointers();
        SpawnGrid(wayPointerIndexes);
        Instantiate(shar, new Vector3(-100, 0, 0), new Quaternion(0, 0, 0, 0));
        Instantiate(shar, new Vector3(-110, 0, 0), new Quaternion(0, 0, 0, 0));
        //foreach (var ind in wayPointerIndexes)
        //Debug.Log(ind);
    }
    void SpawnGrid(List<int> wayPointerIndexes)
    {
        int index = 0;
        for (int x = 0; x < GridX; x++)
        {
            for (int y = 0; y < GridY; y++)
            {
                var spawnPosition = new Vector3(x * GridSpacingOffset, 0, y * GridSpacingOffset) + GridZeroPoint;
                PickAndSpawn(spawnPosition, Quaternion.identity, index, wayPointerIndexes);
                index++;
            }
        }
    }
    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn, int index, List<int> wayPointerIndexes)
    {
        int id = 0;
        if (hashSet.Contains(index)) id = 1;
        var clone = Instantiate(itemsToPickFrom[id], positionToSpawn, rotationToSpawn);
        if (id == 0) clone.GetComponent<NodeMainScript>().ID = index;
        else
        {
            clone.GetComponent<pathScript>().ID = index;
            if (wayPointerIndexes.Contains(index))
            {
                clone.GetComponent<pathScript>().waypointer = new GameObject();
                //Debug.Log(index + " " + wayPointerIndexes.IndexOf(index) + " " + wayPointers.Length);
                wayPointers[wayPointerIndexes.IndexOf(index)] = clone;
                
                //Debug.Log(clone.transform.position);
            }
        }
    }

    List<int> CreateWayPointers()
    {
        var wayPointIndexes = new List<int>() { 1, 17, 21, 133, 138, 202, 201, 233, 239 };
        return wayPointIndexes;
    }
}
