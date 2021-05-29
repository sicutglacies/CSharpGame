using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AdvancedButton;

public class UIControlScript : MonoBehaviour
{
    public Canvas canvas;

    private Transform container;
    private Transform shopItemTemplate;
    private float shopItemHeight = 400;

    private string desrcLvL1 = "Description: " +
        "It just shoots and damages enemies \n"
      + "Best choice you can get at the start";

    private string desrcLvL2 = "Description: " +
        "Well, now you are gonna have some \n" +
        "more firepower and abuse points more effectively";

    void Awake()
    {

        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopTemplate");
    }
    void Start()
    {    
        CreateItemButton(Item.ReturnTexture(Item.ItemType.TurretLvL1), desrcLvL1, "Turret Lvl. 1",
            Item.ReturnCost(Item.ItemType.TurretLvL1), Item.ItemType.TurretLvL1);

        CreateItemButton(Item.ReturnTexture(Item.ItemType.TurretLvL2), desrcLvL2, "Turret Lvl. 2",
            Item.ReturnCost(Item.ItemType.TurretLvL2), Item.ItemType.TurretLvL2);   

        Destroy(shopItemTemplate.gameObject);
    }
    void CreateItemButton(Texture texture, string descrText, string itemName, int itemCost, Item.ItemType type)
    {
        
        Transform shopItem = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRect = shopItem.GetComponent<RectTransform>();


        shopItemRect.anchoredPosition = new Vector2(37, shopItemHeight);
        shopItemHeight -= 700f;

        shopItem.Find("ItemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItem.Find("ItemCost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItem.Find("ItemImage").GetComponent<RawImage>().texture = texture;
        shopItem.Find("ItemDescr").GetComponent<TextMeshProUGUI>().SetText(descrText);
        
        BuySome button =  shopItem.Find("BuyButton").GetComponent<BuySome>();

        if (type == Item.ItemType.TurretLvL1)
        {
            button.tag = "LvL1";       
        }
                       
        else
        {
            shopItem.Find("ItemImage").GetComponent<RectTransform>().localScale = 
                new Vector3(1.15375f, 1.569445f, 1.17f);
            Destroy (shopItem.Find("UpdateButton").gameObject);
            button.tag = "LvL2";
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
