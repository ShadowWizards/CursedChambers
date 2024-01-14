
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Classes;
using UnityEngine;
using UnityEngine.UI;

namespace Player_Scripts
{
    public class PlayerInventoryFunctions : MonoBehaviour
    {

        private int _invCanvasChildren;
        private GameObject _inventoryGameObject;
        private GameObject _invCanvas;
        private int _invSlotAdd;
        private Vector2 _invCanvasPos;
        private Player _playerClass;
        private GameObject _clickableSlots;

        private void Start()
        {
            _playerClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            _invCanvas = GameObject.FindGameObjectWithTag("Inventory_Canvas");
            _inventoryGameObject = GameObject.FindGameObjectWithTag("Inventory");
            _clickableSlots = GameObject.FindGameObjectWithTag("ClickableSlots");

            HideClickableSlots();
            
            _inventoryGameObject.SetActive(false);
        }

        // Add Item to the player's Inventory
        public void AddItem(Item.ItemEnum itemType)
        {
            // Get the amount of items already existing in the Inventory Canvas
            _invCanvasChildren = _invCanvas.transform.childCount;
            
            // Create Item Object
            Item item = _invCanvas.AddComponent<Item>();
            item.ItemType = itemType;
            item.Slot = $"Slot {_invCanvasChildren + 1}";
            
            // A check if the item already exists in the player's inventory
            bool itemExists = ItemExists(item);
            
            // Making sure the item doesn't already exist, and that there are no more than 1 healing items
            if (HealingItemExists() && item.IsHealing)
            {
                Debug.Log("You already have a healing item");
            }
            else if (itemExists)
            {
                Debug.Log("You already have this item");
            }
            else
            {
                _playerClass.inventory.Add(item);

                GenerateInvEntries();
            }
        }

        // Remove Item from the Player's Inventory
        public void RemoveItem(Item item)
        {
            // Making sure the inventory is not empty
            if (_playerClass.inventory.Count == 0)
            {
                return;
            }

            // Getting the Item object from the Inventory
            //Item item = _playerClass.inventory.FirstOrDefault(x => x.ItemType.Equals(itemType));

            if (ItemExists(item))
            {
                _playerClass.inventory.Remove(item);
                RemoveInvEntry(item);
                ReOrganizeSlots();
                Debug.Log("Item removed");
            }
            else
            {
                Debug.Log("Item does not exist");
            }
        }

        // A simple check if the Item already exists in the Player's Inventory
        public bool ItemExists(Item item)
        {
            
            switch (_playerClass.inventory)
            {
                case { } items when _playerClass.inventory.Contains(_playerClass.inventory.FirstOrDefault(x => x.ItemType.Equals(item.ItemType))):
                    return true;
            }

            return false;
        }

        // A check if the item chosen to be checked is a healing one
        public bool HealingItemExists()
        {
            switch (_playerClass.inventory)
            {
                case { } orange when _playerClass.inventory.Contains(_playerClass.inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Orange))):
                case { } grape when _playerClass.inventory.Contains(_playerClass.inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Grape))):
                case { } pineapple when _playerClass.inventory.Contains(_playerClass.inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Pineapple))):
                case { } peach when _playerClass.inventory.Contains(_playerClass.inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Peach))):
                case { } pitahaya  when _playerClass.inventory.Contains(_playerClass.inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Pitahaya))):
                case { } pepper when _playerClass.inventory.Contains(_playerClass.inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Pepper))):
                    return true;
                default:
                    return false;
            }
        }

        // This will reorganize the whole Inventory, meaning that it will re-render all the items
        // It will make sure that any left over removed Items will not be displayed
        public void ReOrganizeSlots()
        {
            if (_playerClass.inventory.Count == 0)
            {
                HideClickableSlots();
                return;
            }
            _invCanvasChildren = _invCanvas.transform.childCount;
            _invSlotAdd = 1;
            
            foreach (var item in _playerClass.inventory)
            {
                RemoveInvEntry(item);
                HideClickableSlots();
                GameObject itemFrame = new GameObject($"Slot {_invSlotAdd}");
                item.Slot = $"Slot {_invSlotAdd}";
                _clickableSlots.transform.Find($"Slot {_invSlotAdd}").gameObject.SetActive(true);
                Image image =  itemFrame.AddComponent<Image>();
                image.sprite = Item.GetSprite(item.ItemType);
                image.color = Color.white;
                
                RectTransform rectTransform = itemFrame.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(95, 95);
                rectTransform.localPosition = GetInvSlotPosition(_invSlotAdd);
                
                itemFrame.transform.SetParent(_invCanvas.transform);
                _invSlotAdd++;
            }
           
        }
        
        // Removes the visual entry of an Item in the Inventory
        public void RemoveInvEntry(Item item)
        {
            GameObject slotToRemove = GameObject.Find(item.Slot);
            Destroy(slotToRemove);
        }
        
        // This function will generate new entries to the player Inventory
        // It is better to call this function rather than "ReOrganizeSlots",when adding new items
        // since this one will only add new entries and not re-enter and re-render all items
        public void GenerateInvEntries()
        {
            
            if (_playerClass.inventory.Count == 0)
            {
                return;
            }
            _invCanvasChildren = _invCanvas.transform.childCount;
            _invSlotAdd = _invCanvasChildren + 1;
            
            if (_invCanvasChildren == _playerClass.inventory.Count)
            {
                Debug.Log("All items are generated");
                return;
            }
            
            for (int i = 0; i < _playerClass.inventory.Count - _invCanvasChildren; i++)
            {
                GameObject itemFrame = new GameObject($"Slot {_invSlotAdd}");
                _playerClass.inventory[_invCanvasChildren].Slot = $"Slot {_invSlotAdd}";
                _clickableSlots.transform.Find($"Slot {_invSlotAdd}").gameObject.SetActive(true);
                Image image =  itemFrame.AddComponent<Image>();
                image.sprite = Item.GetSprite(_playerClass.inventory[_invCanvasChildren].ItemType);
                image.color = Color.white;
                
                RectTransform rectTransform = itemFrame.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(95, 95);
                rectTransform.localPosition = GetInvSlotPosition(_invSlotAdd);
                
                itemFrame.transform.SetParent(_invCanvas.transform);
                _invSlotAdd++;
            }
            
            
        }
        
        // This function will return the exact position of each Inventory slot
        public Vector2 GetInvSlotPosition(int invSlot)
        {
            _invCanvasPos = _invCanvas.transform.position;
            switch (invSlot)
            {
                case 1:
                    return new Vector2(_invCanvasPos.x + -148, _invCanvasPos.y + 197);
                case 2:
                    return new Vector2(_invCanvasPos.x + 1, _invCanvasPos.y + 197); 
                case 3:
                    return new Vector2(_invCanvasPos.x + 148, _invCanvasPos.y + 197);
                case 4:
                    return new Vector2(_invCanvasPos.x + -148, _invCanvasPos.y + (float)-39.5);
                case 5:
                    return new Vector2(_invCanvasPos.x + 1, _invCanvasPos.y + (float)-39.5); 
                case 6:
                    return new Vector2(_invCanvasPos.x + 148, _invCanvasPos.y + (float)-39.5);
                case 7:
                    return new Vector2(_invCanvasPos.x + -148, _invCanvasPos.y + -278);
                case 8:
                    return new Vector2(_invCanvasPos.x + 1, _invCanvasPos.y + -278); 
                case 9:
                    return new Vector2(_invCanvasPos.x + 148, _invCanvasPos.y + -278);
                default:
                    return new Vector2(0, 0);
            }
        }

        public void OpenInventory()
        {
            if (!_inventoryGameObject.activeSelf)
            {
                _inventoryGameObject.SetActive(true);
                GenerateInvEntries();
            }
            else
            {
                _inventoryGameObject.SetActive(false);
            }
        }

        public void HideClickableSlots()
        {
            foreach (Transform child in _clickableSlots.transform)
            {
                child.gameObject.SetActive(false);
                
            }
        }
        
    }

   
}