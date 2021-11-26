using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    private GameManagerSingleton _gameManager = null;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerSingleton>();
    }

    public void SetVolume(float newVolume)
    {
        Debug.Log("New volume : " + (newVolume * 100));
        _gameManager.SetVolume(newVolume);
    }
}
