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

    void Awake()
    {

        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopTemplate");
    }
    void Start()
    {    
        CreateItemButton(Item.ReturnTexture(Item.ItemType.TurretLvL1), "Turret Lvl. 1",
            Item.ReturnCost(Item.ItemType.TurretLvL1), Item.ItemType.TurretLvL1);

        CreateItemButton(Item.ReturnTexture(Item.ItemType.TurretLvL2), "Turret Lvl. 2",
            Item.ReturnCost(Item.ItemType.TurretLvL2), Item.ItemType.TurretLvL2);   

        Destroy(shopItemTemplate.gameObject);
    }
    void CreateItemButton(Texture texture, string itemName, int itemCost, Item.ItemType type)
    {
        
        Transform shopItem = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRect = shopItem.GetComponent<RectTransform>();


        shopItemRect.anchoredPosition = new Vector2(37, shopItemHeight);
        shopItemHeight -= 700f;

        shopItem.Find("ItemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItem.Find("ItemCost").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItem.Find("ItemImage").GetComponent<RawImage>().texture = texture;

        
        BuySome button =  shopItem.Find("Button").GetComponent<BuySome>();
        if (type == Item.ItemType.TurretLvL1)
            button.tag = "LvL1";
        else
            button.tag = "LvL2";

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
