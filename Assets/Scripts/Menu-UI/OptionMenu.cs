using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    private GameManagerSingleton _gameManager = null;
    [SerializeField] private Slider _volume;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerSingleton>();
        _volume.value = _gameManager.GetVolume();
    }

    public void SetVolume(float newVolume)
    {
        _gameManager.SetVolume(newVolume);
    }
}
