using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using CodeMonkey.Utils;

public class UI_Shop : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;
    private IShopCustomer shopCustomer;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
    }

    private void Start()
    {
        CreateItemButton(Item.ItemEnum.Fruit1, Item.GetSprite(Item.ItemEnum.Fruit1), "Orange", Item.GetCost(Item.ItemEnum.Fruit1), 0);
        CreateItemButton(Item.ItemEnum.Fruit2, Item.GetSprite(Item.ItemEnum.Fruit2), "Grape", Item.GetCost(Item.ItemEnum.Fruit2), 1);
        CreateItemButton(Item.ItemEnum.Fruit3, Item.GetSprite(Item.ItemEnum.Fruit3), "Pineapple", Item.GetCost(Item.ItemEnum.Fruit3), 2);
        CreateItemButton(Item.ItemEnum.Fruit4, Item.GetSprite(Item.ItemEnum.Fruit4), "Peach", Item.GetCost(Item.ItemEnum.Fruit4), 3);
        CreateItemButton(Item.ItemEnum.Fruit5, Item.GetSprite(Item.ItemEnum.Fruit5), "Pitahaya", Item.GetCost(Item.ItemEnum.Fruit5), 4);
        CreateItemButton(Item.ItemEnum.Fruit6, Item.GetSprite(Item.ItemEnum.Fruit6), "Peper", Item.GetCost(Item.ItemEnum.Fruit6), 5);
        CreateItemButton(Item.ItemEnum.Fruit6, Item.GetSprite(Item.ItemEnum.Fruit6), "Peper", Item.GetCost(Item.ItemEnum.Fruit6), 6);
        CreateItemButton(Item.ItemEnum.Fruit6, Item.GetSprite(Item.ItemEnum.Fruit6), "Peper", Item.GetCost(Item.ItemEnum.Fruit6), 7);
        CreateItemButton(Item.ItemEnum.Fruit6, Item.GetSprite(Item.ItemEnum.Fruit6), "Peper", Item.GetCost(Item.ItemEnum.Fruit6), 8);
        shopItemTemplate.gameObject.SetActive(false);
        Hide();
    }

    private void CreateItemButton(Item.ItemEnum itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        
        float shopItemHeight = 0f;
        float shopItemWidth = 147f * (positionIndex % 3);

        if(positionIndex == 0 || positionIndex == 1 || positionIndex == 2)
            shopItemHeight = 0f;
        else if(positionIndex == 3 || positionIndex == 4 || positionIndex == 5)
            shopItemHeight = 240f;
        else
            shopItemHeight = 480f;

        
        shopItemRectTransform.anchoredPosition = new Vector2(shopItemWidth, -shopItemHeight);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<UnityEngine.UI.Image>().sprite = itemSprite;

       shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => {
            // Clicked on shop item button
            TryBuyItem(itemType);
       };
    }

    private void TryBuyItem(Item.ItemEnum itemType)
    {
        shopCustomer.BoughtItem(itemType);
    }

    public void Show(IShopCustomer shopCustomer)
    {
        this.shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
