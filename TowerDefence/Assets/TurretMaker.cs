using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMaker : MonoBehaviour
{
    public GameObject turret;
    // Start is called before the first frame update
    void Start()
    {
        CreateTurret();
    }

    void CreateTurret()
    {
        Instantiate(turret, turret.transform.position, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
