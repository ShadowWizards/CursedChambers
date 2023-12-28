using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitControl : MonoBehaviour
{
    private Transform container;

    void Awake()
    {
        container = transform.Find("ExitContainer");
        container.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        container.gameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collider) {
        container.gameObject.SetActive(false);
    }
}
