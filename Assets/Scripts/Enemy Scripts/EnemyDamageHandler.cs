using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    private GameObject _playerObject;
    private GameObject _slash;
    private Enemy _enemy;
    private float _invincibilityTimer;
    private SpriteRenderer _slashSpriteRenderer;
    private SpriteRenderer _enemySpriteRenderer;
    private RewardHandler _rewardHandler;
    // Start is called before the first frame update
    public void OnTriggerStay2D(Collider2D collision2D)
    {
        
        Debug.Log("collision");
        // Destroy the enemy object when health gets to 0
        if (_enemy.Hp <= 0)
        {
            _rewardHandler.addCurrency(_enemy.CoinDropped);
            _rewardHandler.addScore(_enemy.ScoreReward);
            Destroy(_enemy.gameObject);
        }

        // Makes sure the player is not already attacking as well as that the attack delay has finished
        if (Time.time >= _invincibilityTimer && collision2D.CompareTag("Attack") && _slashSpriteRenderer.sprite.name == "slash_0")
        {
            
            Debug.Log("Hit");
            _enemySpriteRenderer.color = Color.red;
            _enemy.Hp -= 2;

            _invincibilityTimer = Time.time + (float)0.65;

            // Knockback
            Rigidbody2D enemy = GetComponent<Rigidbody2D>();
            Vector2 difference = _playerObject.transform.position - transform.position;
            difference = difference.normalized * -7f;
            enemy.AddForce(difference, ForceMode2D.Impulse);
        }
        else
        {
            _enemySpriteRenderer.color = Color.white;
        }
    }

    void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        foreach (Transform child in _playerObject.transform)
        {
            if (child.CompareTag("Attack"))
            {
                _slash = child.gameObject;
            }
        }
        _enemy = GetComponent<Enemy>();
        _enemySpriteRenderer = GetComponent<SpriteRenderer>();
        _slashSpriteRenderer = _slash.GetComponent<SpriteRenderer>();
        _rewardHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<RewardHandler>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
