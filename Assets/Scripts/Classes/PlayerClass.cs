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
        public double Speed;
        public int inventorySpace;
        public Buff[] buffs;
        public Debuff[] debuffs;

    }
}
