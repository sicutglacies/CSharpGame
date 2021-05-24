using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wayPointerIndex;
    private GameObject[] wayPointers;

    void Start()
    {
        wayPointers = GameObject.Find("GridSpawner").GetComponent<SpanGridScript>().wayPointers;
        target = wayPointers[0].transform;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position + new Vector3(0, 2, 0);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position + new Vector3(0, 2, 0)) <= 0.2f)
        {
            GetNextWayPointer();
        }
    }

    void GetNextWayPointer()
    {
        if (wayPointerIndex >= wayPointers.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wayPointerIndex++;
        target = wayPointers[wayPointerIndex].transform;
    }
}
