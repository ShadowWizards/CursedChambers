using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerObject;
    private Player _playerClass;
    void Start()
    {
        _playerClass = playerObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        _playerClass.Speed = 5;
    }
    
}
