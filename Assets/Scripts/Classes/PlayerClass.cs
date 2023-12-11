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
        public Buff[] buffs;
        public Debuff[] debuffs;
        
        public float invincibilityDuration;
        public float invincibilityTimer;
        public bool isInvincible;

        public void Update()
        {
            if(invincibilityTimer > 0)
            {
                invincibilityTimer -= Time.deltaTime;
            }
            else if(isInvincible)
            {
                isInvincible = false;
            }
        }
        public void TakeDamage(float Dmg){
           if(!isInvincible){

           
            Hp -= Dmg;
            invincibilityTimer = invincibilityDuration;
            isInvincible = true;
            if(Hp<=0){
                Kill();
            }
            
           }
           
        }
         public void Kill(){
                Destroy(gameObject);
            }
                
    }

}
