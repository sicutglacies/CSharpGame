using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        TurretLvL1,
        TurretLvL2
    }
    public static int ReturnCost(ItemType itemType)
    {
        switch (itemType)
        {          
            case ItemType.TurretLvL1:
                return 50;
            case ItemType.TurretLvL2:
                return 150;
            default:
                return 0;
        }
    }
    public static Texture ReturnTexture(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.TurretLvL1:
                return GameAssetsScript.Instance.TowerLvL1;
            case ItemType.TurretLvL2:
                return GameAssetsScript.Instance.TowerLvL2;
            default:
                return null;

        }
    }
}

