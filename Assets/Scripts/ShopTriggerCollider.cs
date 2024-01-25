using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTriggerCollider : MonoBehaviour
{
    [SerializeField] private ExitShopController _exitShopController;

    private void Awake()
    {
        _exitShopController = GameObject.FindGameObjectWithTag("Player").GetComponent<ExitShopController>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
            _exitShopController.ShowShop();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        IShopCustomer shopCustomer = collider.GetComponent<IShopCustomer>();
        if (shopCustomer != null)
        {
            _exitShopController.CloseShop();
        }
    }
}
