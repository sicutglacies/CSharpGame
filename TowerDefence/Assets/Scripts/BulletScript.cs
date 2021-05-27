using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform targetOfBullet;
    private float speed = 100f;

    public GameObject particlesEffect;
    public void FindATarget(Transform targetFromTurret)
    {
        this.targetOfBullet = targetFromTurret;
    }

    void HitTarget ()
    {
        GameObject effectInstance = (GameObject) Instantiate(particlesEffect, 
            transform.position, transform.rotation);
        Destroy(effectInstance, 2f);
        Destroy(this.gameObject);
        var enemyScript = GetNearestEnemy()?.GetComponent<EnemyScript>();
        enemyScript.health--;
    }
    void Update()
    {
        if (targetOfBullet is null)
        {
            Destroy(gameObject); 
            return;
        }

        Vector3 dir = targetOfBullet.position - transform.position;
        float distanceToBeMovedForThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceToBeMovedForThisFrame)
        {
            HitTarget(); 
            return;
        }
        transform.Translate(dir.normalized * distanceToBeMovedForThisFrame, Space.World);
    }

    GameObject GetNearestEnemy()
    {
        var shortestDistance = double.PositiveInfinity;
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject selectedEnemy = null;
        foreach (var enemy in enemies)
        {
            var distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                selectedEnemy = enemy;
            }
        }
        return selectedEnemy;
    }
}
