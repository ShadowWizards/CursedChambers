using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Classes
{
    public class Enemy : MonoBehaviour
    {
        public double Hp;
        public double Str;
        public double Def;
        public double Speed;
        public bool Friendly;
        public bool Alive;
        public string[] buffs;
        public string[] debuffs;
    }
}
