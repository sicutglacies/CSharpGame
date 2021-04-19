using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour
{
    public int state, id;
    public Color normCol, pathCol;
    // private Material materialColored;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void SetState(int i)
    {
        state = i;

        if (i == 0)
            GetComponent<Renderer>().material.color = normCol;
        if (i == 1)
            GetComponent<Renderer>().material.color = pathCol;
    }

    //public void SetPosition(int x, int y)
    //{
    //    GetComponent<Renderer>().transform.position
    //}
}
