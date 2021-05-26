using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanerScript : MonoBehaviour
{
    public GameObject Enemy;
    private float delay = 3f;
    private float countDown = 2f;
    static private int waveCount = 3;
    static private int enemyCount = 3;
    public readonly int EnemyRemaining = waveCount * enemyCount;
    
    void Start()
    {
        
    }

     void OnMouseDown()
     {
        Instantiate(Enemy, transform.position, transform.rotation);
     }

    void Update()
    {
        if (countDown <= 0f && waveCount > 0)
        {
            StartCoroutine(SpawnWave());
            waveCount--;
            countDown = delay;
        }

        countDown -= Time.deltaTime;
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(Enemy, this.transform.position, this.transform.rotation);
    }
}
