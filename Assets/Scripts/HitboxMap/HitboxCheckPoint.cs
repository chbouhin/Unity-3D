using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxCheckPoint : MonoBehaviour
{
    [SerializeField] private GameManagerSingleton _gameManagerSingleton;

    private void Start()
    {
        _gameManagerSingleton = GameObject.Find("GameManager").GetComponent<GameManagerSingleton>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameManagerSingleton._checkPoint = true;
        _gameManagerSingleton._savePosition = transform.position;
    }
}
