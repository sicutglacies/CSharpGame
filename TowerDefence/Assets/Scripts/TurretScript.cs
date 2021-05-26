using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint; // position of bullet 

    private Transform target;
    private float rangeOfAttack = 15.0f;
    private readonly string enemyTag = "Enemy";

    private float fireRate = 1f;
    private float fireCountDown = 0f;

    
    
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0.5f, 0.5f);
        
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
            target = selectedEnemy.transform;
        else
        {
            var min = GameObject.FindGameObjectsWithTag("Plitka").Min(x => Vector3.Distance(x.transform.position, this.transform.position));
            var plitka = GameObject.FindGameObjectsWithTag("Plitka").FirstOrDefault(x => Vector3.Distance(x.transform.position, this.transform.position) == min);
            target = plitka.transform;
        }
    }

    void Update()
    {
        if (target == null) return;
        
        Vector3 direction = target.transform.position - this.transform.position;
        Vector3 lookRotation = Quaternion.LookRotation(direction).eulerAngles;

        Transform partToRotate = this.transform.Find("CorrectPartToRotate");
        partToRotate.transform.rotation = Quaternion.Euler(lookRotation.x, lookRotation.y, lookRotation.z);

        if (fireCountDown <= 0f && target.name != "pathPref(Clone)")
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }

    public void Shoot()
    {
        GameObject spawnedBullet = (GameObject) Instantiate (bulletPrefab, 
            firePoint.position, firePoint.rotation);

        BulletScript bulletScript = spawnedBullet.GetComponent<BulletScript>();
        if (bulletScript is null)
        {
            Debug.Log("Bullet is null");
        }
        bulletScript.FindATarget(target);
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