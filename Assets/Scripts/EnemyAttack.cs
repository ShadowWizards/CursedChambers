using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // References
    public double damage;

    private void OnCollisionStay2D(Collision2D collision)
    {
      // Check if Enemy collides with Player
      if (collision.gameObject.CompareTag("Player"))
      {
        PlayerDamageHandler player = collision.gameObject.GetComponent<PlayerDamageHandler>();
        damage = GetComponent<Enemy>().Str;
        player.TakeDamage(damage);
      }
    }
}