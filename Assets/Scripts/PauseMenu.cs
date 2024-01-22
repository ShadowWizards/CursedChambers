using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // References
    private static bool _gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        _gameIsPaused = false;
    }
    // Turns off the pause menu after it is referenced by other scripts, that's why it's in OnGui, rather than in the Start
    void OnGUI()
    {
        if(!_gameIsPaused)
            this.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        _gameIsPaused = !_gameIsPaused;
        if(_gameIsPaused)
        {
            Time.timeScale = 0f;
            this.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
        }
    }

    public void ContinueGame()
    {
        PauseGame();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
