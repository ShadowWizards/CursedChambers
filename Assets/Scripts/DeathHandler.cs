using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class DeathHandler : MonoBehaviour
{
    private GameObject EndScreen;
    private Animator _animatorDeath;
    private Animator _animatorVictory;
    private GameObject _deathContainer;
    private GameObject _victoryContainer;
    private Player _player;
    private Rigidbody2D _playerRigidBody;
    private GameObject _inventory;
    // Start is called before the first frame update
    void Start()
    {
        EndScreen = GameObject.Find("UI_EndScreen");
        _animatorDeath = GameObject.Find("DeathText").GetComponent<Animator>();
        _animatorVictory = GameObject.Find("VictoryText").GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
        _playerRigidBody = _player.GetComponent<Rigidbody2D>();
        _deathContainer = GameObject.Find("Death");
        _victoryContainer = GameObject.Find("Victory");
        _deathContainer.SetActive(false);
        _victoryContainer.SetActive(false);
        EndScreen.SetActive(false);
    }

    public void playerIsDead()
    {
        // Makes the end screen visible
        EndScreen.SetActive(true);
        _deathContainer.SetActive(true);

        // Sets the death state in the player class and deathScreen animator booleans
        _animatorDeath.SetBool("playerIsDead", true);
        _player.isAlive = false;

        GameObject.Find("ScoreAmount").GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255);
        GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = new Color32(255, 0, 0, 255);

        // Turns off all other UI and stops player from moving
        EndGameFunctions();
    }
    public void PlayerWon()
    {
        // Makes the end screen visible
        EndScreen.SetActive(true);
        _victoryContainer.SetActive(true);

        // Sets the death state in the player class and deathScreen animator booleans
        _animatorVictory.SetBool("playerWon", true);
        _player.isAlive = false;

        GameObject.Find("ScoreAmount").GetComponent<TextMeshProUGUI>().color = new Color32(255, 215, 45, 255);
        GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().color = new Color32(255, 215, 45, 255);

        // Turns off all other UI and stops player from moving
        EndGameFunctions();
    }
    public void EndGameFunctions()
    {
        // Sets speed float in the player animator, so player animations stop
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetFloat("Speed", 0);

        // Turns off inventory UI and Shop UI
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
