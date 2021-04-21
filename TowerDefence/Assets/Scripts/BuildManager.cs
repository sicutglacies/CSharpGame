using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instanceOfManager;
    public GameObject defaultPrefab;

    private GameObject objectToPlaceOn;   
    void Awake()
    {
        instanceOfManager = this;
    }

    private void Start()
    {
        objectToPlaceOn = defaultPrefab;
    }

    public GameObject BuildThis()
    {
        return objectToPlaceOn;
    }



}
