using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMO : MonoBehaviour
{
    [SerializeField] private GameObject enemy,player;
    public float spawnTime=2f;
    private float _endTime;
    private void Start()
    {
        _endTime = spawnTime;
    }
    private void Update()
    {
        _endTime -= Time.deltaTime;
        if (_endTime <= 0)
        {
            Instantiate(enemy, SelectSpawnPoint(), Quaternion.identity);
            _endTime=spawnTime;
        }
    }
    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = new Vector3(player.transform.position.x,player.transform.position.y+15,player.transform.position.z);

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;
        if (spawnVerticalEdge)
        {
            spawnPoint = new Vector3(Random.Range((player.transform.position.x-20),(player.transform.position.x+20)),transform.position.y+15, Random.Range((player.transform.position.z+2),(player.transform.position.z+20)));
        }
        return spawnPoint;
    }
}
