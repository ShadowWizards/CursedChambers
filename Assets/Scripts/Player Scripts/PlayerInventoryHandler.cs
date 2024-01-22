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
        private Player _playerClass;
        private PlayerInventoryFunctions _inventoryFunctions;

        
        
        void Start()
        {
            _playerClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            
            _inventoryFunctions = _playerClass.GetComponent<PlayerInventoryFunctions>();

            //_inventoryFunctions.AddItem(Item.ItemEnum.Fruit2,_invCanvas,_playerClass);
            
        }

        void Update()
        {
           
        }

        
    }
}