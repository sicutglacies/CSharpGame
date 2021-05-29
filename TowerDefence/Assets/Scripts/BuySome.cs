using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuySome : MonoBehaviour
{
    public void BuyTurret()
    {
        GameObject node = GameObject.FindGameObjectWithTag("Building").gameObject;
        PlayerScript player = GameObject.Find("GridSpawner").GetComponentInChildren<PlayerScript>();

        if (node == null) 
            return;
        NodeMainScript scriptOfNode = node.GetComponent<NodeMainScript>();

        Transform canvas = scriptOfNode.canvas;
        Transform shopItemTemplate = scriptOfNode.shopItemTemplate;

        switch (this.tag)
        {
            case "LvL1":
                GameObject fTempObj = (GameObject) GameAssetsScript.Instance.TurretObject_1;
                scriptOfNode.placedOn =
                    Instantiate(fTempObj, node.transform.position + 
                    new Vector3 { x = 0, y = 0.5f, z = 0 }, node.transform.rotation);
                player.PlayerMoney -= Item.ReturnCost(Item.ItemType.TurretLvL1);
                break;

            case "LvL2":
                if (player.PlayerMoney - Item.ReturnCost(Item.ItemType.TurretLvL2) < 0)
                    break;   
                GameObject sTempObj = (GameObject) GameAssetsScript.Instance.TurretObject_2;
                scriptOfNode.placedOn = 
                    Instantiate(sTempObj, node.transform.position + 
                    new Vector3 { x = 0, y = 0.5f, z = 0 }, node.transform.rotation);
                player.PlayerMoney -= Item.ReturnCost(Item.ItemType.TurretLvL2);
                break;
        }

        node.tag = "Untagged";
        shopItemTemplate.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
        return;       
    }
}
