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

    private Item _itemToUse;
    // Start is called before the first frame update
    void Start()
    {
        _playerClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _inventoryFunctions = _playerClass.GetComponent<PlayerInventoryFunctions>();
        _interactionButtons = GameObject.FindGameObjectWithTag("InteractionButtons");
        _interactionButtons.SetActive(false);
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

        if (!_itemToUse.IsHealing)
        {
            Debug.Log("Item cannot be used");
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
