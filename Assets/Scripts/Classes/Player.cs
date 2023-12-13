using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    public class Player : MonoBehaviour
    {
        public float Hp;
        public float Str;
        public float Def;
        public float Speed;
        public int inventorySpace;
        public float invincibilityDuration;
        public float playerCooldown;
        public Buff[] buffs;
        public Debuff[] debuffs;
    }

}
