using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    // References
    private float _invincibilityTimer;
    private bool _isInvincible;
    private Player _player;
    private SpriteRenderer _spriteRenderer;
    private float _flashDuration = 0.15f;
    private float _flashTimer;
    private HealthBar _healthBar;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GetComponent<Player>();
        _healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // Decrease invincibility timer until it reaches 0, then sets invincibility to false
        if(_invincibilityTimer > 0)
        {
            _invincibilityTimer -= Time.deltaTime;
        }
        else if(_isInvincible)
        {
            _isInvincible = false;
        }

        // Decrease flash timer until it reaches 0, then sets spriteRenderer back to normal
        if(_flashTimer > 0)
        {
            _flashTimer -= Time.deltaTime;
        }
        else
        {
            _spriteRenderer.color = Color.white;
        }
    }

    public void TakeDamage(float dmg)
    {
        dmg += Random.Range(-1, 2);
        if(dmg < 0)
            dmg = 0;

        // If Player is not invincible they take damage
        if(!_isInvincible)
        {
            _player.Hp -= dmg;
            _invincibilityTimer = _player.invincibilityDuration;
            _isInvincible = true;
            _healthBar.SetHealth(_player.Hp);

            // Sets Player spriteRender to red, to indicate damage taken
            FlashDamage();

            // Destroy Player object once hp is 0
            if(_player.Hp <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Time.timeScale = 0f;
        //Destroy(_player.gameObject);
    }

    public void FlashDamage()
    {
        _spriteRenderer.color = Color.red;
        _flashTimer = _flashDuration;
    }
}
