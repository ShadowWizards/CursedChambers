using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using Player_Scripts;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInventoryFunctions _inventoryFunctions;
    
    private GameObject _invCanvas;

    private Player _playerClass;

    private Item _item;
    void Start()
    {
        _item = gameObject.AddComponent<Item>();
        _playerClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _inventoryFunctions = _playerClass.GetComponent<PlayerInventoryFunctions>();
        _invCanvas = GameObject.FindGameObjectWithTag("Inventory_Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFruit2()
    {
        _inventoryFunctions.AddItem(Item.ItemEnum.Grape);
    }

    public void AddBuff()
    {
        _inventoryFunctions.AddItem(Item.ItemEnum.Pepper);
    }

    public void RemoveFruit2()
    {
        _item.ItemType = Item.ItemEnum.Grape;
        _inventoryFunctions.RemoveItem(_item);
    }

    public void RemoveBuff()
    {
        _item.ItemType = Item.ItemEnum.Pepper;
        _inventoryFunctions.RemoveItem(_item);
    }
    
}
