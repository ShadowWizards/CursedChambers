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
        _inventoryFunctions.AddItem(Item.ItemEnum.Fruit2);
    }

    public void AddBuff()
    {
        _inventoryFunctions.AddItem(Item.ItemEnum.TestBuffItem);
    }

    public void RemoveFruit2()
    {
        _item.ItemType = Item.ItemEnum.Fruit2;
        _inventoryFunctions.RemoveItem(_item);
    }

    public void RemoveBuff()
    {
        _item.ItemType = Item.ItemEnum.TestBuffItem;
        _inventoryFunctions.RemoveItem(_item);
    }
    
}
