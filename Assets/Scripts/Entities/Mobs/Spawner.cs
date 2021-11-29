using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _mobs;
    [SerializeField] private Transform _spawnPos;
    private float _timer = 0f;
    [SerializeField] private float _timerBeforeSpawn = 15f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _timerBeforeSpawn) {
            _timer -= _timerBeforeSpawn;
            Instantiate(_mobs[Random.Range(0, _mobs.Count)], _spawnPos.position, Quaternion.identity);
        }
    }
}
