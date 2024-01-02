using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static bool _gameIsPaused;
    private Transform container;
    private Transform canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = transform.Find("Canvas");
        container = canvas.Find("container");
        container.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _gameIsPaused = !_gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if(_gameIsPaused)
        {
            Time.timeScale = 0f;
            container.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            container.gameObject.SetActive(false);
        }
    }

    public void ContinueGame()
    {
        _gameIsPaused = false;
        PauseGame();
    }

    public void MainMenu()
    {
        _gameIsPaused = false;
        PauseGame();
        SceneManager.LoadScene(0);
    }
}
