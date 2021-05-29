using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   Static builder for each node.
/// </summary>
public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    public GameObject DefaultObject;
    public GameObject WishedObject { set; get; }

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        WishedObject = DefaultObject;
    }
    

}