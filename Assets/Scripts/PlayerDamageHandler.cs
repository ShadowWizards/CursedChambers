using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    // References
    public float invincibilityTimer;
    public bool isInvincible;
    public PlayerClass player;
    public double Hp;
    public SpriteRenderer spriteRenderer;
    public float flashDuration = 0.15f;
    public float flashTimer;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<PlayerClass>();
        Hp = player.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease invicibility timer until it reaches 0, then sets invicibility to false
        if(invincibilityTimer > 0)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if(isInvincible)
        {
            isInvincible = false;
        }

        // Decrease flash timer until it reaches 0, then sets spriteRenderer back to normal
        if(flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
        }
        else if(isInvincible)
        {
            spriteRenderer.color = Color.white;
        }
    }

    public void TakeDamage(double Dmg)
    {
        // If Player is not invincible they take damage
        if(!isInvincible)
        {
            Hp -= Dmg;
            invincibilityTimer = player.invincibilityDuration;
            isInvincible = true;

            // Sets Player spriteRender to red, to indicate damage taken
            FlashDamage();

            // Destroy Player object once hp is 0
            if(Hp <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Destroy(player.gameObject);
    }

    public void FlashDamage()
    {
        spriteRenderer.color = Color.red;
        flashTimer = flashDuration;
    }
}
