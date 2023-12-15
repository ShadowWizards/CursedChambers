using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    // References
    private float _speed;
    private Enemy _enemy;
    private Transform _player;

    void Start()
    {
        // Assign Enemy speed
        _speed = GetComponent<Enemy>().Speed;

        // Assign Player object
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        // Direction from opponent to Player
        Vector2 direction = (_player.position - transform.position).normalized;

        // Change player sprite drawing direction
        if (direction.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0,180,0);
        }
        else if(direction.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        // Enemy movement towards the Player
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed*Time.deltaTime);
    }
}
