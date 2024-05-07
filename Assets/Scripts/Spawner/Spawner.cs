using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnerMods
{
    Fixed,
    Random
}
public class Spawner : MonoBehaviour
{
    [Header("Settings")]

    [SerializeField] public SpawnerMods spawnMod = SpawnerMods.Fixed;

    [SerializeField] private float enemyCount = 10;

    [Header("Fixed Delay")]
    [SerializeField] private float delayBtwSpawns;

    [Header("Random Delay")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    private Waypoint _waypoint;
    private ObjectPooler _pooler;

    private float _spawntimer;
    private int _enemiesSpawned;

    private void Awake()
    {
        _waypoint = GetComponent<Waypoint>();
        _pooler = GetComponent<ObjectPooler>();
    }

    private void Update()
    {
        _spawntimer -= Time.deltaTime;
        if(_spawntimer < 0)
        {
            _spawntimer= GetSpawnDelay(); 

            if(_enemiesSpawned < enemyCount) 
            {
                _enemiesSpawned++;
                SpawnEnemy();
            }
        }
    }
    private void SpawnEnemy()
    {
        GameObject newIstance = _pooler.GerInstanceFromPool();
        Enemy enemy  = newIstance.GetComponent<Enemy>();
        enemy.Waypoint = _waypoint;

        enemy.transform.localPosition =transform.position;

        newIstance.SetActive(true);
    }

    private float GetSpawnDelay()
    {
        float delay = 0f;

        if(spawnMod == SpawnerMods.Fixed) 
        {
            delay = delayBtwSpawns;
        }
        else
        {
            delay = GetRandomDelay();
        }
        return delay;
    }

    private float GetRandomDelay()
    {
        float randomTimer = Random.Range(minRandomDelay, maxRandomDelay);

        return randomTimer;
    }


}



