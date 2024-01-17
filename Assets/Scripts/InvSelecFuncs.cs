using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Classes;
using Player_Scripts;
using UnityEngine;
using UnityEngine.UI;

public class InvSelecFuncs : MonoBehaviour
{
    private GameObject _interactionButtons;

    private Button _currentButton;

    private Player _playerClass;

    private PlayerInventoryFunctions _inventoryFunctions;

    private GameObject _invCanvas;

    private Item _itemToUse;
    private HealthBar _healthBar;
    // Start is called before the first frame update
    void Start()
    {
        _invCanvas = GameObject.FindGameObjectWithTag("Inventory_Canvas");
        _playerClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _inventoryFunctions = _playerClass.GetComponent<PlayerInventoryFunctions>();
        _interactionButtons = GameObject.FindGameObjectWithTag("InteractionButtons");
        _interactionButtons.SetActive(false);
        _healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        _healthBar.SetMaxHealth(_playerClass.MaxHp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick(Button button)
    {
        _currentButton = button;
        _interactionButtons.SetActive(true);
        _interactionButtons.transform.localPosition = new Vector2(x: button.transform.localPosition.x + 6, y: button.transform.localPosition.y + 93);
    }

    public void UseItem()
    {
        
        Debug.Log("Used " + _currentButton.name);
        _itemToUse = _playerClass.inventory.FirstOrDefault(x => x.Slot.Equals(_currentButton.name));
        
        if (_itemToUse == null || _currentButton == null)
        {
            return;
        }

        if (!_itemToUse.IsHealing && !_itemToUse.IsConsumableShield && !_itemToUse.GivesSpeed && !_itemToUse.GiveMaxHp)
        {
            Debug.Log("Item cannot be used");
            return;
        }

        if (_itemToUse.IsHealing)
        {
            _playerClass.Hp = Mathf.Min(_playerClass.Hp += Item.GetHp(_itemToUse.ItemType), _playerClass.MaxHp);
            _healthBar.SetHealth(_playerClass.Hp);
        }

        if (_itemToUse.IsConsumableShield)
        {
            _playerClass.Shield += Item.GetShield(_itemToUse.ItemType);
            _healthBar.SetShield(_playerClass.Shield);
        }

        if (_itemToUse.GivesSpeed || _itemToUse.GiveMaxHp)
        {
            if (_itemToUse.isEquipped)
            {
                Debug.Log("Item is already equipped");
                return;
            }

            foreach (Transform item in _invCanvas.transform)
            {
                if (item.gameObject.name.StartsWith($"Equip Slot {_itemToUse.ItemType.ToString().Substring(0,3)}"))
                {
                    return;
                }
            }
            
            _itemToUse.isEquipped = true;
            _inventoryFunctions.GenerateEquipSlots();
            _inventoryFunctions.ApplyEquipableEffects();
            Debug.Log("Item has been equipped");
            _interactionButtons.SetActive(false);
            _currentButton = null;
            return;
        }
        
        _inventoryFunctions.RemoveItem(_itemToUse);
        _interactionButtons.SetActive(false);
        _currentButton = null;
    }

    public void RemoveItem()
    {
        _itemToUse = _playerClass.inventory.FirstOrDefault(x => x.Slot.Equals(_currentButton.name));
        if (_itemToUse == null || _currentButton == null)
        {
            return;
        }
        
        _inventoryFunctions.RemoveItem(_itemToUse);
        _interactionButtons.SetActive(false);
        _currentButton = null;
    }
}
