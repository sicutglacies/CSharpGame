using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAssetsScript : MonoBehaviour
{
    public Texture TowerLvL1;
    public Texture TowerLvL2;

    public GameObject TurretObject_1;
    public GameObject TurretObject_2;
    public Button UpdateButton;

    private static GameAssetsScript instance;
    public static GameAssetsScript Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load("GameAssets") as GameObject)
                      .GetComponent<GameAssetsScript>();
            }                
            return instance; 
        }
    }
}
