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
    private float _distance;
    private bool _followPlayer = false;
    public float detectionRange = 5;
    public float giveUpRange = 10;

    void Start()
    {
        // Assign Enemy speed
        _speed = GetComponent<Enemy>().Speed;

        // Assign Player object
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        _distance = Vector2.Distance(_player.position, transform.position);

        // The enemy keeps checking the distance between it and the player until it reaches the detection range, then follows the player until it goes out of range
        if(!_followPlayer)
        {
            if(_distance <= detectionRange)
            {
                _followPlayer = true;
            }
        }
        else
        {
            MoveTowardsPlayer();
            if(_distance >= giveUpRange)
            {
                _followPlayer = false;
            }
        }
    }

    void MoveTowardsPlayer()
    {
        // Direction from opponent to Player
        Vector2 direction = (_player.position - transform.position).normalized;

        // Change enemy sprite drawing direction
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
