using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using Player_Scripts;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Player _playerClass;
    private PlayerInventoryFunctions _inventoryFunctions;
    private PauseMenu _pauseMenu;
    private DialogWindow _dialogWindow;
    // Start is called before the first frame update
    void Start()
    {
        _playerClass = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _inventoryFunctions = _playerClass.GetComponent<PlayerInventoryFunctions>();
        _pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();
        _dialogWindow = GameObject.FindGameObjectWithTag("UI_Canvas").GetComponent<DialogWindow>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_playerClass.isAlive)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu.PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            _inventoryFunctions.OpenInventory();
            
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            //_dialogWindow.InitializeDialog("Attention","Your mom is gae");
        }
    }
}
