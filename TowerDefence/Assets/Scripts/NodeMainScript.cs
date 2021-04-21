using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMainScript : MonoBehaviour
{
    public Color defaultColor;
    public Color changedColor;

    private Renderer quickRend;
    private GameObject placedOnCurrent;

    void Start()
    {
        ColorUtility.TryParseHtmlString("#9D9F9F", out defaultColor);
        ColorUtility.TryParseHtmlString("#222525", out changedColor);

        quickRend = GetComponent<Renderer>();
        quickRend.material.color = defaultColor;
    }

    void OnMouseEnter()
    {
        Debug.Log("Entered");
        quickRend.material.color = changedColor;
    }
    void OnMouseExit()
    {
        Debug.Log("Entered");
        quickRend.material.color = defaultColor;
    }
    void OnMouseDown()
    {
       if (placedOnCurrent != null)  {
            Debug.Log("It is impossible to place another object on the current node");        
            return;
            //TO DO in a form of bubble message
        }
        var tempObj = BuildManager.instanceOfManager.BuildThis();
        placedOnCurrent = Instantiate(tempObj, transform.position, transform.rotation) as GameObject;
    
    }
}
