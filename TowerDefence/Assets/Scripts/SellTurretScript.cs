using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellTurretScript : MonoBehaviour
{
    private GameObject node;

    public void SellTurret()
    {
        try
        {
            node = GameObject.FindGameObjectWithTag("UpdradingOrSelling").gameObject;
        }
        catch
        {
            node = null;
        }

        if (node == null)
            return;
        PlayerScript player = GameObject.Find("GridSpawner").GetComponentInChildren<PlayerScript>();
        NodeMainScript scriptOfNode = node.GetComponent<NodeMainScript>();
        Transform shopItemTemplate = scriptOfNode.shopItemTemplate;
        Transform canvas = scriptOfNode.canvas;

        switch (scriptOfNode.placedOn.name.ToString())
        {
            case "TurretLvl1(Clone)":
                player.PlayerMoney += Item.ReturnCost(Item.ItemType.TurretLvL1) - 10;
                break;

            case "TurretLvl2(Clone)":
                player.PlayerMoney += Item.ReturnCost(Item.ItemType.TurretLvL2) - 30;
                break;
        }

        Destroy(scriptOfNode.placedOn.gameObject);

        node.tag = "Untagged";
        shopItemTemplate.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);

        return;
    }
}
