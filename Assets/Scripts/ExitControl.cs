using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControl : MonoBehaviour
{
    private Transform container;
    private bool isInRange = false;
    public int sceneBuildIndex;

    void Awake()
    {
        container = transform.Find("ExitContainer");
        container.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        container.gameObject.SetActive(true);
        isInRange = true;    
    }

    private void OnTriggerExit2D(Collider2D collider) {
        container.gameObject.SetActive(false);
        isInRange = false;
    }
}
