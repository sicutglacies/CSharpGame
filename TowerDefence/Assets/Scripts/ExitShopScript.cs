using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShopScript : MonoBehaviour
{
    public void ExitShop()
    {
        GameObject node = null;
        GameObject buildingNode = GameObject.FindGameObjectWithTag("Building")?.gameObject;

        node = (buildingNode != null) ?
            GameObject.FindGameObjectWithTag("Building").gameObject
            :
            GameObject.FindGameObjectWithTag("UpdradingOrSelling").gameObject;

        Debug.Log(node);
        NodeMainScript scriptOfNode = node.GetComponent<NodeMainScript>();

        Transform canvas = scriptOfNode.canvas;
        Transform shopItemTemplate = scriptOfNode.shopItemTemplate;

        node.tag = "Untagged";
        shopItemTemplate.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);

        return;
    }

}
