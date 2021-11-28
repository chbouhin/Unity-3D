using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _textScore;
    [SerializeField] private Objective _obj;
    private GameManagerSingleton _gameManager = null;

    private void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManagerSingleton>();
    }

    private void Start()
    {
        _textScore.text = "Score : " + _gameManager.GetCurrentScore().ToString("00000.##");
    }

    public void AddScore(int score)
    {
        if (_obj != null)
            _obj.UpdateObj(score);
        _gameManager.AddToScore(score);
        _textScore.text = "Score : " + _gameManager.GetCurrentScore().ToString("00000.##");
    }
}