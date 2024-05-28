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

    [SerializeField] private int enemyCount = 10;
    [SerializeField] private float delayBtwWaves = 1f;

    [Header("Fixed Delay")]
    [SerializeField] private float delayBtwSpawns;

    [Header("Random Delay")]
    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    private Waypoint _waypoint;
    private ObjectPooler _pooler;

    private float _spawntimer;
    private int _enemiesSpawned;
    private int _enemiesRamaning;

    private void Awake()
    {
        _waypoint = GetComponent<Waypoint>();
        _pooler = GetComponent<ObjectPooler>();

        _enemiesRamaning = enemyCount;
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
        enemy.ResetEnemy();

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

    private IEnumerator NextWave()
    {
        yield return new WaitForSeconds(delayBtwWaves);
        _enemiesRamaning = enemyCount;
        _spawntimer = 0;
        _enemiesSpawned = 0;
    }
    private void RecordEnemy(Enemy enemy)
    {
        _enemiesRamaning--;
        if(_enemiesRamaning <= 0) 
        {
            StartCoroutine(NextWave());
        }
    }
    private void OnEnable()
    {
        Enemy.OnEndReached += RecordEnemy;
        EnemyHealth.OnEnemyKilled += RecordEnemy;
    }

    private void OnDisable()
    {
        Enemy.OnEndReached -= RecordEnemy;
        EnemyHealth.OnEnemyKilled -= RecordEnemy;

    }

}



