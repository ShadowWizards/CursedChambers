using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    public event EventHandler OnItemListChanged;

    private List<InventoryItem> itemList;
    private Action<InventoryItem> useItemAction;

    public Inventory(Action<InventoryItem> useItemAction) {
        this.useItemAction = useItemAction;
        itemList = new List<InventoryItem>();

        AddItem(new InventoryItem { itemType = InventoryItem.ItemType.Sword, amount = 1 });
        AddItem(new InventoryItem { itemType = InventoryItem.ItemType.HealthPotion, amount = 1 });
        AddItem(new InventoryItem { itemType = InventoryItem.ItemType.ManaPotion, amount = 1 });
    }

    public void AddItem(InventoryItem item) {
        if (item.IsStackable()) {
            bool itemAlreadyInInventory = false;
            foreach (InventoryItem inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true;
                }
            }
            if (!itemAlreadyInInventory) {
                itemList.Add(item);
            }
        } else {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItemAmount(InventoryItem.ItemType itemType, int amount) {
        RemoveItem(new InventoryItem { itemType = itemType, amount = amount });
    }

    public void RemoveItem(InventoryItem item) {
        if (item.IsStackable()) {
            InventoryItem itemInInventory = null;
            foreach (InventoryItem inventoryItem in itemList) {
                if (inventoryItem.itemType == item.itemType) {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0) {
                itemList.Remove(itemInInventory);
            }
        } else {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem(InventoryItem item) {
        useItemAction(item);
    }

    public List<InventoryItem> GetItemList() {
        return itemList;
    }

}
