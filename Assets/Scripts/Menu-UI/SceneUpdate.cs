using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUpdate : MonoBehaviour
{
    private GameManagerSingleton _gameManagerSingleton;

    private void Start()
    {
        _gameManagerSingleton = GameObject.Find("GameManager").GetComponent<GameManagerSingleton>();
    }

    public void LoadScene(string scene)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NextScene()
    {
        _gameManagerSingleton._checkPoint = false;
        if (SceneManager.GetActiveScene().buildIndex < 2)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene("Menu");
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}