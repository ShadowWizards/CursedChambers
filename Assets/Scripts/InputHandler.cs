using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using Player_Scripts;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private GameObject _inventoryGameObject;

    private GameObject _invCanvas;

    private Player _playerClass;

    private PlayerInventoryFunctions _inventoryFunctions;
    private PauseMenu _pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        _inventoryGameObject = GameObject.FindGameObjectWithTag("Inventory");
        _playerClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _invCanvas = GameObject.FindGameObjectWithTag("Inventory_Canvas");
        _inventoryFunctions = gameObject.AddComponent<PlayerInventoryFunctions>();
        _pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
        _inventoryGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu.PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log(_inventoryGameObject.tag);
            if (!_inventoryGameObject.activeSelf)
            {
                OpenInventory();
            }
            else
            {
                CloseInventory();
            }
            
        }
    }
    void OpenInventory()
    {
        _inventoryGameObject.SetActive(true);
        _inventoryFunctions.GenerateInvEntries(_playerClass.inventory,_invCanvas);
        
    }

    void CloseInventory()
    {
        _inventoryGameObject.SetActive(false);
    }
}
