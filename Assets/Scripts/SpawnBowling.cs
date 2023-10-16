using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBowling : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyToSpawn;
    [SerializeField] private float _spawnTime, _endTime/*spawncounter*/;
    //[SerializeField] private Transform _minSpawnPoint, _maxSpawnPoint;
    [SerializeField] private Transform[] _enemySpawnPoints;
    [SerializeField] private int _spawnPointNumber;

   

    void Start()
    {
        _endTime = _spawnTime;
    
    }


    void Update()
    {
        _endTime -= Time.deltaTime;
        if (_endTime <= 0)
        {
            if (_spawnPointNumber < 50)
            {
                _endTime = _spawnTime;
                int randomRangeNumberToSpawn = Random.Range(0, 5);
                Instantiate(_enemyToSpawn[Random.Range(0, _enemyToSpawn.Length)], _enemySpawnPoints[randomRangeNumberToSpawn].position, transform.rotation);
                _spawnPointNumber++;
            }
        }

        
    }
}

