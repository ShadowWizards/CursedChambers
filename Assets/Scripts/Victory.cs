using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private GameObject _player;
    private Transform _container;
    private bool isInRange = false;
    private FadeInOut fade;
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _container = transform.Find("ExitContainer");
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeInOut>();
        _container.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            fade.WinScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        _container.gameObject.SetActive(true);
        isInRange = true;    
    }

    private void OnTriggerExit2D(Collider2D collider) {
        _container.gameObject.SetActive(false);
        isInRange = false;
    }
}
