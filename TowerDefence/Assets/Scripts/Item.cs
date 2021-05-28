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
            default:
            case ItemType.TurretLvL1:
                return 50;
            case ItemType.TurretLvL2:
                return 150;
        }
    }
    public static Texture ReturnTexture(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.TurretLvL1:
                return GameAssetsScript.Instance.TowerLvL1;
            case ItemType.TurretLvL2:
                return GameAssetsScript.Instance.TowerLvl2;
        }
    }
}

