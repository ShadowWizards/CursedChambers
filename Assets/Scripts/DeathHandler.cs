using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using Unity.VisualScripting;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    private GameObject deathScreen;
    private Animator _animator;
    private Player _player;
    private Rigidbody2D _playerRigidBody;
    private GameObject _shop;
    private GameObject _inventory;
    // Start is called before the first frame update
    void Start()
    {
        deathScreen = GameObject.Find("UI_DeathScreen");
        _animator = GameObject.Find("DeathText").GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _shop = GameObject.Find("Shop");
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
        _playerRigidBody = _player.GetComponent<Rigidbody2D>();
        deathScreen.SetActive(false);
    }

    public void playerIsDead()
    {
        // Makes the deathscreen visible
        deathScreen.SetActive(true);

        // Sets the death state in the player class and deathScreen animator booleans
        _animator.SetBool("playerIsDead", true);
        _player.isAlive = false;

        // Sets speed float in the player animator, so player animations stop
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetFloat("Speed", 0);

        // Turns off inventory UI and Shop UI
        _shop.SetActive(false);
        _inventory.SetActive(false);

        // Stops player from continuing movement after death
        _playerRigidBody.velocity = new Vector2(0, 0);

        // Stops other enemies pushing the player after death
        _playerRigidBody.isKinematic = true;
    }
    public void stopTime()
    {
        Time.timeScale = 0f;
    }
}
