using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    // References
    private float speed;
    private Enemy enemy;
    private Transform player;

    void Start()
    {
        // Assign Enemy speed
        speed = GetComponent<Enemy>().Speed;

        // Assign Player object
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Direction from opponent to Player
        Vector2 direction = (player.position - transform.position).normalized;

        // Enemy movement towards the Player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
    }
}
