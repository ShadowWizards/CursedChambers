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
    void Start()
    {
        _inventoryFunctions = gameObject.AddComponent<PlayerInventoryFunctions>();
        _playerClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _invCanvas = GameObject.FindGameObjectWithTag("Inventory_Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFruit2()
    {
        _inventoryFunctions.AddItem(Item.ItemEnum.Fruit2,_invCanvas,_playerClass);
    }

    public void AddBuff()
    {
        _inventoryFunctions.AddItem(Item.ItemEnum.TestBuffItem,_invCanvas,_playerClass);
    }

    public void RemoveFruit2()
    {
        _inventoryFunctions.RemoveItem(Item.ItemEnum.Fruit2,_invCanvas,_playerClass);
    }

    public void RemoveBuff()
    {
        _inventoryFunctions.RemoveItem(Item.ItemEnum.TestBuffItem,_invCanvas,_playerClass);
    }
    
}
