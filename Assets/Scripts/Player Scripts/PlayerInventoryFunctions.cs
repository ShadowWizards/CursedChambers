
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Classes;
using Unity.VisualScripting;
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
        public bool AddItem(Item.ItemEnum itemType)
        {
            // Get the amount of items already existing in the Inventory Canvas
            _invCanvasChildren = 0;
            foreach (Transform child in _invCanvas.transform)
            {
                if (child.gameObject.name.StartsWith("Slot"))
                {
                    _invCanvasChildren++;
                }
            }
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
                return false;
            }
            else if (itemExists)
            {
                Debug.Log("You already have this item");
                return false;
            }
            else
            {
                _playerClass.inventory.Add(item);

                GenerateInvEntries();
                return true;
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
                if (item.isEquipped)
                {
                    item.isEquipped = false;
                    GenerateEquipSlots();
                    ApplyEquipableEffects();
                    Debug.Log("Item unequipped");
                    return;
                }
                _playerClass.inventory.Remove(item);
                RemoveInvEntry(item);
                ReOrganizeSlots();
                GenerateEquipSlots();
                ApplyEquipableEffects();
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
            HideClickableSlots();
            if (_playerClass.inventory.Count == 0)
            {
                return;
            }
            _invCanvasChildren = 0;
            foreach (Transform child in _invCanvas.transform)
            {
                if (child.gameObject.name.StartsWith("Slot"))
                {
                    _invCanvasChildren++;
                }
            }
            _invSlotAdd = 1;
            
            foreach (var item in _playerClass.inventory)
            {
                RemoveInvEntry(item);
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
            _invCanvasChildren = 0;
            foreach (Transform child in _invCanvas.transform)
            {
                if (child.gameObject.name.StartsWith("Slot"))
                {
                    _invCanvasChildren++;
                }
            }
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

        public void GenerateEquipSlots()
        {
            if (_playerClass.inventory.Count == 0)
            {
                return;
            }

            foreach (Transform child in _invCanvas.transform)
            {
                if (child.gameObject.name.StartsWith("Equip Slot"))
                {
                    Destroy(child.gameObject);
                }
            }

            foreach (var item in _playerClass.inventory)
            {
                if (item.GivesSpeed || item.GiveMaxHp || item.GiveStr)
                {
                    if (item.isEquipped)
                    {
                        GameObject itemFrame = new GameObject($"Equip Slot {item.ItemType.ToString()}");
                        Image image =  itemFrame.AddComponent<Image>();
                        image.sprite = Item.GetSprite(item.ItemType);
                        image.color = Color.white;
                        
                        RectTransform rectTransform = itemFrame.GetComponent<RectTransform>();
                        rectTransform.sizeDelta = new Vector2(55, 55);
                        rectTransform.localPosition = GetEquipSlot(item.ItemType);
                        itemFrame.transform.SetParent(_invCanvas.transform);
                    }
                }
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

        public Vector2 GetEquipSlot(Item.ItemEnum itemType)
        {
            switch (itemType)
            {
                case Item.ItemEnum.HelmetBlue:
                    return new Vector2(_invCanvasPos.x + -152, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.HelmetBrown:
                    return new Vector2(_invCanvasPos.x + -152, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.HelmetRed:
                    return new Vector2(_invCanvasPos.x + -152, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.HelmetSilver:
                    return new Vector2(_invCanvasPos.x + -152, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.HelmetYellow:
                    return new Vector2(_invCanvasPos.x + -152, _invCanvasPos.y + (float)386.4);
                
                case Item.ItemEnum.HatBlue:
                    return new Vector2(_invCanvasPos.x + -152, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.HatBrown:
                    return new Vector2(_invCanvasPos.x + -152, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.HatRed:
                    return new Vector2(_invCanvasPos.x + -152, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.HatSilver:
                    return new Vector2(_invCanvasPos.x + -152, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.HatYellow:
                    return new Vector2(_invCanvasPos.x + -152, _invCanvasPos.y + (float)386.4);
                
                case Item.ItemEnum.ArmourBlue:
                    return new Vector2(_invCanvasPos.x + (float)-76.1, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.ArmourBrown:
                    return new Vector2(_invCanvasPos.x + (float)-76.1, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.ArmourRed:
                    return new Vector2(_invCanvasPos.x + (float)-76.1, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.ArmourSilver:
                    return new Vector2(_invCanvasPos.x + (float)-76.1, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.ArmourYellow:
                    return new Vector2(_invCanvasPos.x + (float)-76.1, _invCanvasPos.y + (float)386.4);
                
                case Item.ItemEnum.GlovesBlue:
                    return new Vector2(_invCanvasPos.x + (float)1.7, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.GlovesBrown:
                    return new Vector2(_invCanvasPos.x + (float)1.7, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.GlovesRed:
                    return new Vector2(_invCanvasPos.x + (float)1.7, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.GlovesSilver:
                    return new Vector2(_invCanvasPos.x + (float)1.7, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.GlovesYellow:
                    return new Vector2(_invCanvasPos.x + (float)1.7, _invCanvasPos.y + (float)386.4);
                
                case Item.ItemEnum.BootsBlue:
                    return new Vector2(_invCanvasPos.x + (float)76.4, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.BootsBrown:
                    return new Vector2(_invCanvasPos.x + (float)76.4, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.BootsRed:
                    return new Vector2(_invCanvasPos.x + (float)76.4, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.BootsSilver:
                    return new Vector2(_invCanvasPos.x + (float)76.4, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.BootsYellow:
                    return new Vector2(_invCanvasPos.x + (float)76.4, _invCanvasPos.y + (float)386.4);
                
                case Item.ItemEnum.SwordBrown:
                    return new Vector2(_invCanvasPos.x + (float)154.2, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.SwordRed:
                    return new Vector2(_invCanvasPos.x + (float)154.2, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.SwordYellow:
                    return new Vector2(_invCanvasPos.x + (float)154.2, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.SwordSilverAndBlack:
                    return new Vector2(_invCanvasPos.x + (float)154.2, _invCanvasPos.y + (float)386.4);
                case Item.ItemEnum.SwordSilverAndYellow:
                    return new Vector2(_invCanvasPos.x + (float)154.2, _invCanvasPos.y + (float)386.4);
                
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

        public void ApplyEquipableEffects()
        {
            float maxHp = 10;
            float speed = 5;
            float str = 2;
            foreach (var item in _playerClass.inventory)
            {
                if (item.isEquipped)
                {
                    if (item.GiveMaxHp)
                    {
                        maxHp += Item.GetMaxHP(item.ItemType);
                    }

                    if (item.GivesSpeed)
                    {
                        speed += Item.GetSpeed(item.ItemType);
                    }

                    if (item.GiveStr)
                    {
                        str += Item.GetStr(item.ItemType);
                    }
                    
                }
            }

            _playerClass.MaxHp = maxHp;
            _playerClass.Speed = speed;
            _playerClass.Str = str;
        }
        
    }

   
}