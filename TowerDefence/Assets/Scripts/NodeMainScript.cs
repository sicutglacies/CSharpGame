using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls the main behaviour of nodes
/// </summary>
public class NodeMainScript : MonoBehaviour
{
    public int ID;

    private Color defaultColor;
    private Color changedColor;

    private Renderer quickRend;
    private GameObject placedOn;
    private UIControlScript scriptOfUI;

    void Awake()
    {
        quickRend = GetComponent<Renderer>();
        ColorUtility.TryParseHtmlString("#E6ECEC", out defaultColor);
        ColorUtility.TryParseHtmlString("#222525", out changedColor);
        quickRend.material.color = defaultColor;

        scriptOfUI = FindObjectOfType<Canvas>().GetComponentInChildren<UIControlScript>();            
    }

    void OnMouseEnter()
    {
        quickRend.material.color = changedColor;
    }

    void OnMouseExit()
    {
        quickRend.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        if (scriptOfUI is null)
            return;

        scriptOfUI.Show();

        Debug.Log("Done!");

       //var tempObj = BuildManager.Instance.WishedObject;
       // Debug.Log(BuildManager.Instance);
       //placedOn = Instantiate(tempObj, transform.position + new Vector3 { x = 0, y = 0.5f, z = 0}, transform.rotation);
    }
    
}