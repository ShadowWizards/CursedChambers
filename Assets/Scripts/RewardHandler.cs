using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;

public class RewardHandler : MonoBehaviour
{
    // References
    private Player _player;
    public Currency _currency;
    public Score _score;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
    }

    // Adds a value to the players total coin and updates the UI
    public void addCurrency(int value)
    {
        _player.Coins += value;
        _currency.SetCurrency(_player.Coins);
    }

    // Adds a value to the players total score
    public void addScore(int score)
    {
        _player.Score += score;
        _score.SetScore(_player.Score);
    }
}
