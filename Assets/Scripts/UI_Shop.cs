using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using CodeMonkey.Utils;
using Player_Scripts;
using Assets.Scripts.Classes;
using Random=UnityEngine.Random;
using System;


public class UI_Shop : MonoBehaviour
{
    private Transform _container;
    private Transform _shopItemTemplate;
    private IShopCustomer _shopCustomer;
    private PlayerInventoryFunctions _inventoryFunctions;
    private Player _player;
    private RewardHandler _rewardHandler;
    private void Awake()
    {
        _container = transform.Find("container");
        _shopItemTemplate = _container.Find("shopItemTemplate");
        _inventoryFunctions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryFunctions>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _rewardHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<RewardHandler>();
    }

    private void Start()
    {
        // Display the consumables from slot 1 to 3
        for(int i = 0; i < 3; i++)
        {
            Item.ItemEnum currentItem = Item.ItemEnum.Error;

            // Get total weight of all consumables
            int totalWeight = 0;
            for(int j = 0; j < 10; j++)
            {
                totalWeight += Item.GetChance((Item.ItemEnum)j);
            }

            // Get random value of totalWeight
            int random = Random.Range(0, totalWeight);
            for(int j = 0; j < 10; j++)
            {
                random -= Item.GetChance((Item.ItemEnum)j);
                if(random <= 0)
                {
                    currentItem = (Item.ItemEnum)j;
                    break;
                }
            }
            // Gets a random item from ItemEnum, first 10 items are fruits and flasks, the rest are normal items in total 44 items
            CreateItemButton(currentItem, Item.GetSprite(currentItem), Item.GetName(currentItem), Item.GetCost(currentItem), i);
        }

        // Make a new array list where it is populated by unique items from a selection
        var items = new ArrayList();
        while(items.Count < 6)
        {
            Item.ItemEnum currentItem = Item.ItemEnum.Error;

            // Get total weight of all items except consumables
            int totalWeight = 0;
            for(int j = 10; j < 44; j++)
            {
                totalWeight += Item.GetChance((Item.ItemEnum)j);
            }

            // Get random value of totalWeight
            int random = Random.Range(0, totalWeight);
            for(int j = 10; j < 44; j++)
            {
                random -= Item.GetChance((Item.ItemEnum)j);
                if(random <= 0)
                {
                    currentItem = (Item.ItemEnum)j;
                    break;
                }
            }

            if(!items.Contains(currentItem))
            {
                items.Add(currentItem);
            }
        }

        // Display the items from slot 4 to 9
        for(int i = 3; i < 9; i++)
        {
            Item.ItemEnum currentItem = (Item.ItemEnum)items[i - 3];
            CreateItemButton(currentItem, Item.GetSprite(currentItem), Item.GetName(currentItem), Item.GetCost(currentItem), i);
        }
        _shopItemTemplate.gameObject.SetActive(false);
        Hide();
    }

    private void CreateItemButton(Item.ItemEnum itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(_shopItemTemplate, _container);
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
            if(_player.Coins >= Item.GetCost(itemType))
            {
                if(_inventoryFunctions.AddItem(itemType))
                {
                _rewardHandler.addCurrency(-Item.GetCost(itemType));
                _shopCustomer.BoughtItem(itemType);
                Destroy(shopItemTransform.gameObject);
                }
                else
                {
                    Debug.Log("Can't purchase item");
                }
            }
            else
            {
                Debug.Log("Insufficient Coins");
            }
       };
    }
    public void Show(IShopCustomer shopCustomer)
    {
        this._shopCustomer = shopCustomer;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
