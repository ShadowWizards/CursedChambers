using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControl : MonoBehaviour
{
    private GameObject _player;
    private GameObject _UI;
    private Transform _container;
    public FadeInOut fade;
    private bool isInRange = false;
    public int sceneBuildIndex;
    private ExitShopController _shopController;

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _UI = GameObject.Find("UI");
        _container = transform.Find("ExitContainer");
        fade = GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeInOut>();
        _shopController = _player.GetComponent<ExitShopController>();
        _container.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            _shopController.ReGenerateItems();
            StartCoroutine(LoadYourAsyncScene());
        }
    }

    IEnumerator LoadYourAsyncScene()
    {
        // First fade in
        fade.FadeIn();
        yield return new WaitForSeconds(1);

        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneBuildIndex, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(_player, SceneManager.GetSceneByBuildIndex(sceneBuildIndex));
        SceneManager.MoveGameObjectToScene(_UI, SceneManager.GetSceneByBuildIndex(sceneBuildIndex));
        
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);

        // Change player position to the start
        _player.transform.position = new Vector2(0f ,0f);

        // After everything is loaded fade out
        fade.FadeOut();
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
