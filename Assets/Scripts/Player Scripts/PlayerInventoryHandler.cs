using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Classes;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Player_Scripts
{
    public class PlayerInventoryHandler : MonoBehaviour
    {
        private GameObject _playerObject;
        private GameObject _invCanvas;
        private Player _playerClass;
        private List<Item> _playerInventory;
        private PlayerInventoryFunctions _inventoryFunctions;
        private Item _fruit1;

        
        
        void Start()
        {
            _playerObject = GameObject.FindGameObjectWithTag("Player");
            _playerClass = _playerObject.GetComponent<Player>();
            _playerInventory = _playerClass.inventory;
            _invCanvas = GameObject.FindGameObjectWithTag("Inventory_Canvas");
            
            _inventoryFunctions = gameObject.AddComponent<PlayerInventoryFunctions>();
            //_inventoryFunctions.AddItem(Item.ItemEnum.Fruit2,_invCanvas,_playerClass);
            
        }

        void Update()
        {
            //if (_playerInventory.Contains(_playerInventory.FirstOrDefault(x=>x.ItemType == Item.ItemEnum.BuffItem)))
            //{
            //    _playerClass.Speed = 10;
            //}

            
        }

        
    }
}