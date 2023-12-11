using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;




public class EnemyScript : MonoBehaviour
{
    public float damagePerSecond = 10f;
    public double Hp;

    private void OnCollisionStay2D(Collision2D collision)
    {
      
        // Sprawdź, czy zderzyliśmy się z obiektem gracza
        if (collision.gameObject.CompareTag("Player"))
        {
          PlayerClass player = collision.gameObject.GetComponent<PlayerClass>();
          player.TakeDamage(damagePerSecond);
        }
    }
}
