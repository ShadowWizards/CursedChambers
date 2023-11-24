using Assets.Scripts.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerObject;
    private PlayerClass playerClass;
    void Start()
    {
        playerClass = playerObject.GetComponent<PlayerClass>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onButtonClick()
    {
        playerClass.Speed = 5;
    }
    
}
