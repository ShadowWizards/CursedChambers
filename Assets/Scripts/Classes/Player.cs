using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    public class Player : MonoBehaviour, IShopCustomer
    {
        public float Hp;
        public float Str;
        public float Shield;
        public float Speed;
        public int inventorySpace;
        public float invincibilityDuration;
        public float playerCooldown;
        public int Coins;
        public int Score;
        public List<Item> inventory = new List<Item>();
        public Buff[] buffs;
        public Debuff[] debuffs;

        public void BoughtItem(Item.ItemEnum itemType)
        {
            Debug.Log("Bought item" + itemType); 
        }
    }

}
