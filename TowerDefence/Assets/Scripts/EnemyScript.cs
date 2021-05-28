using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 10f;
    public int health = 3;

    private int wayPointerIndex;
    
    private GameObject[] wayPointers;
    private PlayerScript player;
    private Transform target;
    private EnemySpanerScript spawner;

    void Start()
    {
        player = GameObject.Find("GridSpawner").GetComponentInChildren<PlayerScript>();
        wayPointers = GameObject.Find("GridSpawner").GetComponent<SpanGridScript>().wayPointers;
        target = wayPointers[0].transform;
        spawner = GameObject.Find("StartBlock(Clone)").GetComponent<EnemySpanerScript>();
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position + new Vector3(0, 2, 0);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position + new Vector3(0, 2, 0)) <= 0.2f)
            GetNextWayPointer();

        if (health == 0)
        {
            Destroy(gameObject);
            spawner.EnemyRemaining--;
            player.PlayerMoney += 20;
            player.PlayerScore++;
        }
    }

    void GetNextWayPointer()
    {
        if (wayPointerIndex >= wayPointers.Length - 1)
        {
            Destroy(gameObject); 
            player.PlayerHealth--;
            spawner.EnemyRemaining--;
            return;
        }
        wayPointerIndex++;
        target = wayPointers[wayPointerIndex].transform;
    }
}