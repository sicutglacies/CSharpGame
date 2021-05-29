using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTurretScript : MonoBehaviour
{
    public void UpgradeTurret ()
    {
        GameObject node = GameObject.FindGameObjectWithTag("UpdradingOrSelling").gameObject;
        PlayerScript player = GameObject.Find("GridSpawner").GetComponentInChildren<PlayerScript>();
        GameObject LvL2Turret = (GameObject) GameAssetsScript.Instance.TurretObject_2;

        int priceDelta = Item.ReturnCost(Item.ItemType.TurretLvL2) - 
            Item.ReturnCost(Item.ItemType.TurretLvL1);
            
        if (node == null)
            return;

        if (player.PlayerMoney - priceDelta < 0)
            return;

        NodeMainScript scriptOfNode = node.GetComponent<NodeMainScript>();
        Transform shopItemTemplate = scriptOfNode.shopItemTemplate;
        Transform canvas = scriptOfNode.canvas;

        if (scriptOfNode.placedOn.name != "TurretLvl2(Clone)")
        {

            Destroy(scriptOfNode.placedOn.gameObject);
            scriptOfNode.placedOn = Instantiate(LvL2Turret, node.transform.position +
                        new Vector3 { x = 0, y = 0.5f, z = 0 }, node.transform.rotation);
            player.PlayerMoney -= priceDelta;
        }

        node.tag = "Untagged";
        shopItemTemplate.gameObject.SetActive(false);
        canvas.gameObject.SetActive(false);
        return;
    }
}
