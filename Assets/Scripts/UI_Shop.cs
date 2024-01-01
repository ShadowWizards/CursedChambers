using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

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
        CreateItemButton(Item.ItemType.fruit1, Item.GetSprite(Item.ItemType.fruit1), "Orange", Item.GetCost(Item.ItemType.fruit1), 0);
        CreateItemButton(Item.ItemType.fruit2, Item.GetSprite(Item.ItemType.fruit2), "Grape", Item.GetCost(Item.ItemType.fruit2), 1);
        CreateItemButton(Item.ItemType.fruit3, Item.GetSprite(Item.ItemType.fruit3), "Pineapple", Item.GetCost(Item.ItemType.fruit3), 2);
        CreateItemButton(Item.ItemType.fruit4, Item.GetSprite(Item.ItemType.fruit4), "Peach", Item.GetCost(Item.ItemType.fruit4), 3);
        CreateItemButton(Item.ItemType.fruit5, Item.GetSprite(Item.ItemType.fruit5), "Pitahaya", Item.GetCost(Item.ItemType.fruit5), 4);
        CreateItemButton(Item.ItemType.fruit6, Item.GetSprite(Item.ItemType.fruit6), "Peper", Item.GetCost(Item.ItemType.fruit6), 5);
        shopItemTemplate.gameObject.SetActive(false);
        Hide();
    }

    private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 55f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<UnityEngine.UI.Image>().sprite = itemSprite;

       shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => {
            // Clicked on shop item button
            TryBuyItem(itemType);
       };
    }

    private void TryBuyItem(Item.ItemType itemType)
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
