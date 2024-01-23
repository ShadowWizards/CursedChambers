using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Classes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private StoryWindow _storyWindow;
    private void Start()
    {
        _storyWindow = GameObject.FindGameObjectWithTag("UI_Canvas").GetComponent<StoryWindow>();
    }

    public void PlayGame()
    {
        _storyWindow.InitializeStory("In the quiet village of Wintershire, a mysterious dungeon emerges, casting a shadow over the once-peaceful community. Unearthly creatures spill forth, threatening the villagers. Chosen by the village elder, you, [Redacted], a modest blacksmith, armed with a sword and supported by the village, must defeat the supernatural enemies within the dungeon. The villagers believe that by vanquishing these creatures, the dark influence causing the threat will be quelled, and the village can return to its peaceful existence. The dungeon, once a source of fear, transforms into a battleground where a humble blacksmith's bravery determines the fate of the village.",(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }));
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
}
