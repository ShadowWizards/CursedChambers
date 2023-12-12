using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject slash;
    
    private Enemy _enemy;
    private float _invincibilityTimer;
    private SpriteRenderer _slashSpriteRenderer;

    private SpriteRenderer _enemySpriteRenderer;
    // Start is called before the first frame update
    public void OnTriggerStay2D(Collider2D collision2D)
    {
        
        Debug.Log("collision");
        if (_enemy.Hp <= 0)
        {
            Destroy(_enemy.gameObject);
        }

        if (Time.time >= _invincibilityTimer && collision2D.CompareTag("Attack") && _slashSpriteRenderer.sprite.name == "slash_0")
        {
            
            Debug.Log("Hit");
            _enemySpriteRenderer.color = Color.red;
            _enemy.Hp -= 2;

            _invincibilityTimer = Time.time + (float)0.65;
        }
        else
        {
            _enemySpriteRenderer.color = Color.white;
        }
    }

    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _enemySpriteRenderer = GetComponent<SpriteRenderer>();
        _slashSpriteRenderer = slash.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
