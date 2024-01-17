using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random=UnityEngine.Random;

public class EnemyDamageHandler : MonoBehaviour
{
    private GameObject _playerObject;
    private Player _player;
    private GameObject _slash;
    private Enemy _enemy;
    private float _invincibilityTimer;
    private SpriteRenderer _slashSpriteRenderer;
    private SpriteRenderer _enemySpriteRenderer;
    private RewardHandler _rewardHandler;
    private float _flashDuration = 0.15f;
    private float _flashTimer;
    public GameObject popUpDamagePrefab;
    public TMP_Text popUpText;
    // Start is called before the first frame update
    public void OnTriggerStay2D(Collider2D collision2D)
    {
        
        Debug.Log("collision");

        // Makes sure the player is not already attacking as well as that the attack delay has finished
        if (Time.time >= _invincibilityTimer && collision2D.CompareTag("Attack") && _slashSpriteRenderer.sprite.name == "slash_0")
        {
            
            Debug.Log("Hit");
            AudioMenager.Instance.playSFX("EnemyHit");
            _enemySpriteRenderer.color = Color.red;
            _enemy.Hp -= 2;

            float damage = _player.Str + Random.Range(-1, 2);
            if(damage < 0)
                damage = 0;

            _enemy.Hp -= damage;

            //PopUp
            popUpText.text = damage.ToString();
            Instantiate(popUpDamagePrefab, transform.position, Quaternion.identity);

            _invincibilityTimer = Time.time + (float)0.4;

            // Knockback
            Rigidbody2D enemy = GetComponent<Rigidbody2D>();
            Vector2 difference = _playerObject.transform.position - transform.position;
            difference = difference.normalized * -7f;
            enemy.AddForce(difference, ForceMode2D.Impulse);
        }

        // Destroy the enemy object when health gets to 0
        if (_enemy.Hp <= 0)
        {
            _rewardHandler.addCurrency(_enemy.CoinDropped);
            _rewardHandler.addScore(_enemy.ScoreReward);
            Destroy(_enemy.gameObject);
        }
    }
    void FlashDamage()
    {
        _enemySpriteRenderer.color = Color.red;
        _flashTimer = _flashDuration;
    }

    void Start()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _player = _playerObject.GetComponent<Player>();
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
        popUpText = popUpDamagePrefab.transform.Find("Text").GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease flash timer until it reaches 0, then sets spriteRenderer back to normal
        if(_flashTimer > 0)
        {
            _flashTimer -= Time.deltaTime;
        }
        else
        {
            _enemySpriteRenderer.color = Color.white;
        }
    }
}
