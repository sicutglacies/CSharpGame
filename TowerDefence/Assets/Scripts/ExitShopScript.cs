using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShopScript : MonoBehaviour
{
    public void ExitShop()
    {
        GameObject node = GameObject.FindGameObjectWithTag("Building").gameObject;
        NodeMainScript scriptOfNode = node.GetComponent<NodeMainScript>();

        Transform canvas = scriptOfNode.canvas;
        Transform shopItemTemplate = scriptOfNode.shopItemTemplate;

        node.tag = "Untagged";
        shopItemTemplate.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);

        return;
    }

}
