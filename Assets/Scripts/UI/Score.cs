using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _textScore;
    //private int totalScore = 0;
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
        _gameManager.AddToScore(score);
        _textScore.text = "Score : " + _gameManager.GetCurrentScore().ToString("00000.##");
    }
}