using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalVertical : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyToSpawn;
    [SerializeField] private float _spawnTime, _endTime;
    
    [SerializeField] private Transform [] _enemySpawnPoints;
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
            _endTime = _spawnTime; 
            int randomRangeNumberToSpawn = Random.Range(0, 4); 
            Instantiate(_enemyToSpawn[Random.Range(0,_enemyToSpawn.Length)], _enemySpawnPoints[randomRangeNumberToSpawn].position, transform.rotation); 
            
        }
        
    }  
}

