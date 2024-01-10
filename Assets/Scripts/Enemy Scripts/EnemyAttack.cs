using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
      // Check if Enemy collides with Player
      if (collision.gameObject.CompareTag("Player"))
      {
        PlayerDamageHandler player = collision.gameObject.GetComponent<PlayerDamageHandler>();
        player.TakeDamage(GetComponent<Enemy>().Str);
      }
    }
}