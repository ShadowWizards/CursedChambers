using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Classes;

public class DevTools : MonoBehaviour
{
    private RewardHandler _rewardHandler;
    private UI_Shop _UI_Shop;
    public bool devToolsActivated;
    void Awake()
    {
        _rewardHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<RewardHandler>();
        _UI_Shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<UI_Shop>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F12))
        {
            devToolsActivated = true;
        }
        if(devToolsActivated)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                GetCoins(500);
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                RefreshShop();
            }            
        }
    }

    private void GetCoins(int amount)
    {
        _rewardHandler.addCurrency(amount);
    }

    private void RefreshShop()
    {
        _UI_Shop.ReGenerateItems();
    }
}
