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
        CreateItemButton(Item.ItemEnum.Orange, Item.GetSprite(Item.ItemEnum.Orange), "Orange", Item.GetCost(Item.ItemEnum.Orange), 0);
        CreateItemButton(Item.ItemEnum.Grape, Item.GetSprite(Item.ItemEnum.Grape), "Grape", Item.GetCost(Item.ItemEnum.Grape), 1);
        CreateItemButton(Item.ItemEnum.Pineapple, Item.GetSprite(Item.ItemEnum.Pineapple), "Pineapple", Item.GetCost(Item.ItemEnum.Pineapple), 2);
        CreateItemButton(Item.ItemEnum.Peach, Item.GetSprite(Item.ItemEnum.Peach), "Peach", Item.GetCost(Item.ItemEnum.Peach), 3);
        CreateItemButton(Item.ItemEnum.Pitahaya, Item.GetSprite(Item.ItemEnum.Pitahaya), "Pitahaya", Item.GetCost(Item.ItemEnum.Pitahaya), 4);
        CreateItemButton(Item.ItemEnum.Pepper, Item.GetSprite(Item.ItemEnum.Pepper), "Peper", Item.GetCost(Item.ItemEnum.Pepper), 5);
        shopItemTemplate.gameObject.SetActive(false);
        Hide();
    }

    private void CreateItemButton(Item.ItemEnum itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
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
