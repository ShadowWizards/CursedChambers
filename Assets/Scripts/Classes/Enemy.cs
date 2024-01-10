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
        public float Hp;
        public float Str;
        public float Def;
        public float Speed;
        public bool Friendly;
        public bool Alive;
        public Buff[] buffs;
        public Debuff[] debuffs;
        public int CoinDropped;
        public int ScoreReward;
    }
}
