using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls the main behaviour of nodes
/// </summary>
public class NodeMainScript : MonoBehaviour
{
    public int ID;
    public Color defaultColor;
    public Color changedColor;
    //public GameObject thisObject;

    private Renderer quickRend;
    private GameObject placedOn;
    private PlayerScript player;

    void Start()
    {
        player = GameObject.Find("GridSpawner").GetComponentInChildren<PlayerScript>();
        quickRend = GetComponent<Renderer>();

        ColorUtility.TryParseHtmlString("#9D9F9F", out defaultColor);
        ColorUtility.TryParseHtmlString("#222525", out changedColor);

        quickRend.material.color = defaultColor;
        //thisObject = this.gameObject;
    }

    void OnMouseEnter()
    {
        //Debug.Log("Entered");
        quickRend.material.color = changedColor;
    }

    void OnMouseExit()
    {
        //Debug.Log("Exited");
        quickRend.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        if (placedOn != null || player.PlayerMoney < 50)
        {
            Debug.Log("Δενεγ νες, hold on" + player.PlayerMoney.ToString());
            //Debug.Log("It is impossible to place another object on the current node");        
            return;
            //TO DO in a form of bubble message
        }
        var tempObj = BuildManager.Instance.WishedObject;
        Debug.Log(BuildManager.Instance);
        placedOn = Instantiate(tempObj, transform.position + new Vector3 { x = 0, y = 0.5f, z = 0}, transform.rotation);
        player.PlayerMoney -= 50;
        Debug.Log(player.PlayerMoney.ToString());
    }
}