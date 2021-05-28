using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Controls the main behaviour of nodes
/// </summary>
public class NodeMainScript : MonoBehaviour
{
    public int ID;

    public GameObject placedOn;
    public Transform shopItemTemplate;
    public Transform canvas;
    public Color changedColor;
   
    private Color defaultColor;
    private Renderer quickRend; 
    private PlayerScript player;
    

    void Awake()
    {
        quickRend = GetComponent<Renderer>();
        ColorUtility.TryParseHtmlString("#E6ECEC", out defaultColor);
        ColorUtility.TryParseHtmlString("#222525", out changedColor);
        quickRend.material.color = defaultColor;

        player = GameObject.Find("GridSpawner").GetComponentInChildren<PlayerScript>();
        canvas = GameObject.Find("UI").transform.Find("Canvas(Clone)");
        shopItemTemplate = canvas.Find("UIShop").Find("Container");
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

        if (placedOn == null && player.PlayerMoney >= 50)
        {
            if (GameObject.FindGameObjectsWithTag("Building").ToList().Count < 1)
                this.transform.tag = "Building";

            canvas.gameObject.SetActive(true);
            shopItemTemplate.gameObject.SetActive(true);

        }

       
    }   
}