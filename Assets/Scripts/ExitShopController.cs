using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitShopController : MonoBehaviour
{
    private UI_Shop _UI_Shop;
    void Awake()
    {
        _UI_Shop = GameObject.FindGameObjectWithTag("Shop").GetComponent<UI_Shop>();
    }
    public void ReGenerateItems()
    {
        _UI_Shop.ReGenerateItems();
    }
    public void ShowShop()
    {
        _UI_Shop.Show();
    }
    public void CloseShop()
    {
        _UI_Shop.Hide();
    }
}
