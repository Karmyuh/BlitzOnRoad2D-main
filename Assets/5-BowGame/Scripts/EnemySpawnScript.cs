using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] float _minSpawnTime, _maxSpawnTime;
    [SerializeField] GameObject _enemy;
    float _randomSpawnTime, _currentTime;
    private void FixedUpdate()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _randomSpawnTime)
        {
            TuzakSpawnStart();
        }

    }

    void TuzakSpawnStart()
    {
        Instantiate(_enemy, transform.position, _enemy.transform.rotation, transform);
        ResetTuzakSpawn();
    }
    void ResetTuzakSpawn()
    {
        _currentTime = 0;
        _randomSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
}
