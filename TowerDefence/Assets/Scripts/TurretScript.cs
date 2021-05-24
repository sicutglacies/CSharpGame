using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private Transform target;
    private float rangeOfAttack = 15.0f;
    private readonly string enemyTag = "Enemy";
    
    // Start is called before the first frame update
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
                Debug.Log(enemy.name);
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

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        var direction = target.transform.position - this.transform.position;
        // Debug.Log(target.transform.position);
        var lookRotation = Quaternion.LookRotation(direction).eulerAngles;
        // Debug.Log(lookRotation);
        var partToRotate = this.transform.Find("CorrectPartToRotate");
        //partToRotate.transform.position = this.transform.position;
        partToRotate.transform.rotation = Quaternion.Euler(lookRotation.x , lookRotation.y, lookRotation.z );
    }

    /*private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, rangeOfAttack);
    }*/

    //TODO: ??????????? ?????????!!!

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