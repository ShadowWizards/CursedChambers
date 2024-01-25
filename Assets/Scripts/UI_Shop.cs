using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using CodeMonkey.Utils;
using Player_Scripts;
using Assets.Scripts.Classes;
using Random=UnityEngine.Random;
using System;
using Unity.VisualScripting;


public class UI_Shop : MonoBehaviour
{
    private Transform _container;
    private Transform _shopItemTemplate;
    private IShopCustomer _shopCustomer;
    private PlayerInventoryFunctions _inventoryFunctions;
    private Player _player;
    private RewardHandler _rewardHandler;
    private DialogWindow _dialogWindow;
    private void Awake()
    {
        _container = transform.Find("container");
        _shopItemTemplate = _container.Find("shopItemTemplate");
        _inventoryFunctions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventoryFunctions>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _rewardHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<RewardHandler>();
        _dialogWindow = GameObject.FindGameObjectWithTag("UI_Canvas").GetComponent<DialogWindow>();
    }

    private void Start()
    {
        GenerateItems();
        _shopItemTemplate.gameObject.SetActive(false);
        Hide();
    }
    
    private void GenerateItems()
    {
        _shopItemTemplate.gameObject.SetActive(true);
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
    }

    public void ReGenerateItems()
    {
        bool currentlyClosed = !gameObject.activeSelf;
        if(currentlyClosed)
        {
            Show();
        }

        for(int i = 0; i < 9; i++)
        {
            Destroy(GameObject.Find("shopSlot" + i));
        }

        if(currentlyClosed)
        {
            Hide();
        }
        GenerateItems();
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

        shopItemTransform.name = "shopSlot" + positionIndex;

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<UnityEngine.UI.Image>().sprite = itemSprite;

        shopItemTransform.GetComponent<Button_UI>().ClickFunc = () => {
            DialogWindow confirmation = _dialogWindow.InitializeDialog("Attention","Are you sure you want to buy this item?",
                () =>
                {
                    if(_player.Coins >= Item.GetCost(itemType) && _player.inventory.Count < 9)
                    { 
                        if (_inventoryFunctions.AddItem(itemType))
                        {
                            _rewardHandler.addCurrency(-Item.GetCost(itemType));
                            Destroy(shopItemTransform.gameObject);
                        }
                        else
                        {
                            Debug.Log("Can't purchase item");
                        }
                    }
                    else
                    {
                        Debug.Log("Can't purchase item");
                    }
                    _dialogWindow.DestroyDiagComponent();
                },
                () =>
                {
                    _dialogWindow.DestroyDiagComponent();
                    return;
                });
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
}
