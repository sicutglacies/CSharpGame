using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed = 10f;
    private Transform target;
    private int wayPointerIndex;
    private GameObject[] wayPointers;
    public int health = 3;
    private PlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("GridSpawner").GetComponentInChildren<PlayerScript>();
        //Debug.Log(GameObject.Find("GridSpawner").GetComponentInChildren<PlayerScript>());
        wayPointers = GameObject.Find("GridSpawner").GetComponent<SpanGridScript>().wayPointers;
        target = wayPointers[0].transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position + new Vector3(0, 2, 0);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position + new Vector3(0, 2, 0)) <= 0.2f)
            GetNextWayPointer();
        if (health == 0)
        {
            Destroy(gameObject);
            player.PlayerMoney += 20;
            player.PlayerScore++;
        }
    }

    void GetNextWayPointer()
    {
        //Debug.Log("now here");
        if (wayPointerIndex >= wayPointers.Length - 1)
        {
            Destroy(gameObject);
            player.PlayerHealth--;
            Debug.Log("Çהמנמגüו" + player.PlayerHealth);
            return;
        }

        wayPointerIndex++;
        target = wayPointers[wayPointerIndex].transform;
    }
}