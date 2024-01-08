
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
        private int _invSlotAdd;
        private Vector2 _invCanvasPos;

        // Add Item to the player's Inventory
        public void AddItem(Item.ItemEnum itemType, GameObject invCanvas,Player playerClass)
        {
            // Get the amount of items already existing in the Inventory Canvas
            _invCanvasChildren = invCanvas.transform.childCount;
            
            // Create Item Object
            Item item = invCanvas.AddComponent<Item>();
            item.ItemType = itemType;
            item.InvEntry = $"slot{_invCanvasChildren + 1}";
            
            // A check if the item already exists in the player's inventory
            bool itemExists = ItemExists(itemType,playerClass.inventory);
            
            // Making sure the item doesn't already exist, and that there are no more than 1 healing items
            if (HealingItemExists(playerClass.inventory) && item.IsHealing)
            {
                Debug.Log("You already have a healing item");
            }
            else if (itemExists)
            {
                Debug.Log("You already have this item");
            }
            else
            {
                playerClass.inventory.Add(item);

                GenerateInvEntries(playerClass.inventory,invCanvas);
            }
        }

        // Remove Item from the Player's Inventory
        public void RemoveItem(Item.ItemEnum itemType,GameObject invCanvas ,Player playerClass)
        {
            // Making sure the inventory is not empty
            if (playerClass.inventory.Count == 0)
            {
                return;
            }

            // Getting the Item object from the Inventory
            Item item = playerClass.inventory.FirstOrDefault(x => x.ItemType.Equals(itemType));

            if (ItemExists(itemType, playerClass.inventory))
            {
                playerClass.inventory.Remove(item);
                RemoveInvEntry(item);
                ReOrganizeSlots(playerClass.inventory, invCanvas);
                Debug.Log("Item removed");
            }
            else
            {
                Debug.Log("Item does not exist");
            }
        }

        // A simple check if the Item already exists in the Player's Inventory
        public bool ItemExists(Item.ItemEnum itemType, List<Item> inventory)
        {
            
            switch (inventory)
            {
                case { } items when inventory.Contains(inventory.FirstOrDefault(x => x.ItemType.Equals(itemType))):
                    return true;
            }

            return false;
        }

        // A check if the item chosen to be checked is a healing one
        public bool HealingItemExists(List<Item> inventory)
        {
            switch (inventory)
            {
                case { } fruit1 when inventory.Contains(inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Fruit1))):
                case { } fruit2 when inventory.Contains(inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Fruit2))):
                case { } fruit3 when inventory.Contains(inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Fruit3))):
                case { } fruit4 when inventory.Contains(inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Fruit4))):
                case { } fruit5 when inventory.Contains(inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Fruit5))):
                case { } fruit6 when inventory.Contains(inventory.FirstOrDefault(x => x.ItemType.Equals(Item.ItemEnum.Fruit6))):
                    return true;
                default:
                    return false;
            }
        }

        // This will reorganize the whole Inventory, meaning that it will re-render all the items
        // It will make sure that any left over removed Items will not be displayed
        public void ReOrganizeSlots(List<Item> inventory,GameObject invCanvas)
        {
            if (inventory.Count == 0)
            {
                return;
            }
            _invCanvasChildren = invCanvas.transform.childCount;
            _invSlotAdd = 1;
            
            foreach (var item in inventory)
            {
                RemoveInvEntry(item);
                
                GameObject itemFrame = new GameObject($"slot{_invSlotAdd}");
                item.InvEntry = $"slot{_invSlotAdd}";
                Image image =  itemFrame.AddComponent<Image>();
                image.sprite = Item.GetSprite(item.ItemType);
                image.color = Color.white;
                
                RectTransform rectTransform = itemFrame.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(95, 95);
                rectTransform.localPosition = GetInvSlotPosition(_invSlotAdd,invCanvas);
                
                itemFrame.transform.SetParent(invCanvas.transform);
                _invSlotAdd++;
            }
           
        }
        
        // Removes the visual entry of an Item in the Inventory
        public void RemoveInvEntry(Item item)
        {
            GameObject slotToRemove = GameObject.Find(item.InvEntry);
            Destroy(slotToRemove);
        }
        
        // This function will generate new entries to the player Inventory
        // It is better to call this function rather than "ReOrganizeSlots",when adding new items
        // since this one will only add new entries and not re-enter and re-render all items
        public void GenerateInvEntries(List<Item> inventory, GameObject invCanvas)
        {
            
            if (inventory.Count == 0)
            {
                return;
            }
            _invCanvasChildren = invCanvas.transform.childCount;
            _invSlotAdd = _invCanvasChildren + 1;
            
            if (_invCanvasChildren == inventory.Count)
            {
                Debug.Log("All items are generated");
                return;
            }
            
            for (int i = 0; i < inventory.Count - _invCanvasChildren; i++)
            {
                GameObject itemFrame = new GameObject($"slot{_invSlotAdd}");
                inventory[_invCanvasChildren].InvEntry = $"slot{_invSlotAdd}";
                Image image =  itemFrame.AddComponent<Image>();
                image.sprite = Item.GetSprite(inventory[_invCanvasChildren].ItemType);
                image.color = Color.white;
                
                RectTransform rectTransform = itemFrame.GetComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(95, 95);
                rectTransform.localPosition = GetInvSlotPosition(_invSlotAdd,invCanvas);
                
                itemFrame.transform.SetParent(invCanvas.transform);
                _invSlotAdd++;
            }
            
            
        }
        
        // This function will return the exact position of each Inventory slot
        public Vector2 GetInvSlotPosition(int invSlot, GameObject invCanvas)
        {
            _invCanvasPos = invCanvas.transform.position;
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
        
    }

   
}