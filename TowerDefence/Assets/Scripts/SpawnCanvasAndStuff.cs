using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCanvasAndStuff : MonoBehaviour
{
    public Canvas canvas;
    void Awake()
    {
        var ui = GameObject.Find("UI");
        var canvasToSpawn = (Canvas) Instantiate(canvas, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        canvasToSpawn.transform.SetParent(ui.transform);
        canvasToSpawn.gameObject.SetActive(false);
    }
}
