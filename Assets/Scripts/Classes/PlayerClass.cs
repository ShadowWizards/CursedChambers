using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    public class PlayerClass : MonoBehaviour
    {
        public double Hp;
        public double Str;
        public double Def;
        public float Speed;
        public int inventorySpace;
        public float invincibilityDuration;   
        public Buff[] buffs;
        public Debuff[] debuffs;
    }

}
