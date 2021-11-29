using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxCheckPoint : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _explosions;
    [SerializeField] private Transform _explosionPos;
    private GameManagerSingleton _gameManagerSingleton;

    private void Start()
    {
        _gameManagerSingleton = GameObject.Find("GameManager").GetComponent<GameManagerSingleton>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_gameManagerSingleton._checkPoint) {
            _gameManagerSingleton._checkPoint = true;
            _gameManagerSingleton._savePosition = transform.position;
            Instantiate(_explosions[Random.Range(0, _explosions.Count)], _explosionPos.position, Quaternion.identity);
        }
    }
}
