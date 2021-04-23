using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private float rangeOfAttack = 15.0f;
    private readonly string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        SpawnATurret();
        Invoke(nameof(UpdateTarget), Time.deltaTime * 0.5f);
    }

    void UpdateTarget()
    {
        var shortestDistance = double.PositiveInfinity;
        var enemies = GameObject.FindGameObjectsWithTag(enemyTag);
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

        if (selectedEnemy != null && shortestDistance <= rangeOfAttack)
        {
            target = selectedEnemy.transform;
        }
    }

    void SpawnATurret()
    {
        Instantiate(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        var direction = target.transform.position - this.transform.position;
        var lookRotation = Quaternion.LookRotation(direction).eulerAngles;
        this.transform.rotation = Quaternion.Euler(0, 0, lookRotation.z);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeOfAttack);
    }

    //TODO: реализовать интерфейс!!!

    public void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public void Upgrage()
    {
        throw new System.NotImplementedException();
    }

    public void Merge()
    {
        throw new System.NotImplementedException();
    }
}
