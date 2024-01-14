using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;
using CodeMonkey.Utils;
using Player_Scripts;
using Assets.Scripts.Classes;
using System.Threading;
using System;
using System.Linq;
using Random=UnityEngine.Random;
using UnityEditor.Playables;


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
        for(int i = 0; i < 9; i++)
        {
            // Gets a random item from ItemEnum, first 6 items are fruits and the rest are normal items in total 40 items
            Item.ItemEnum currentItem = (Item.ItemEnum)Random.Range(0, 6);
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
