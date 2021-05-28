using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAssetsScript : MonoBehaviour
{
    public Texture TowerLvL1;
    public Texture TowerLvl2;

    private static GameAssetsScript iRef;
    public static GameAssetsScript Instance
    {
        get 
        {
            if (iRef == null)
            {
                iRef = Instantiate(Resources.Load("GameAssets") as GameObject)
                      .GetComponent<GameAssetsScript>();
            }                
            return iRef; 
        }
    }
}
