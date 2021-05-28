using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AdvancedButton;

public class UIControlScript : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private Canvas attachedTo;

    void Awake()
    {
        attachedTo = FindObjectOfType<Canvas>(); 
        attachedTo.gameObject.SetActive(false);

        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopTemplate");

        shopItemTemplate.gameObject.SetActive(false);
    }
    void Start()
    {
        CreateItemButton(Item.ReturnTexture(Item.ItemType.TurretLvL1), "Turret Lvl. 5",
            Item.ReturnCost(Item.ItemType.TurretLvL1), 0, Item.ItemType.TurretLvL1);
        CreateItemButton(Item.ReturnTexture(Item.ItemType.TurretLvL2), "Turret Lvl. 10",
            Item.ReturnCost(Item.ItemType.TurretLvL2), 1, Item.ItemType.TurretLvL2);
    }
    void CreateItemButton(Texture texture, string itemName, int itemCost, int positionIndex, Item.ItemType type)
    {

        float shopItemHeight = 300f;
         
        Transform shopItem = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRect = shopItem.GetComponent<RectTransform>();

        shopItemRect.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItem.Find("ItemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItem.Find("ItemPrice").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItem.Find("ItemImage").GetComponent<RawImage>().texture = texture;

        shopItem.GetComponent<Button_UI>().ClickFunc = () =>
        {
            Show();
        };
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    void TryBuyItem(Item.ItemType type)
    {

    }

}
