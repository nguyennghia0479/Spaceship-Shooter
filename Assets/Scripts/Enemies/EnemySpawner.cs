using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Ship")]
    [SerializeField] private List<ListPrefabInfo> enemyList;
    [SerializeField] private List<WaveInfo> waveInfos;
    [SerializeField] private float minNextWaveTime;
    [SerializeField] private float maxNextWaveTime;

    [Header("Enemy Boss")]
    [SerializeField] private ListPrefabInfo bossPrefabList;
    [SerializeField] private float addNextWaveTime = 20;

    [Header("Cooldown")]
    [SerializeField] private float spawnBossCooldown = 60;
    [SerializeField] private float spawnEnemyCooldown = 120;

    private ListPrefabInfo currentEnemyWave;
    private WaveInfo currentWave;
    private bool isSpawnEnemy = true;
    private bool isSpawnBoss;
    private float spawnBossTimer;
    private float spawnEnemyTimer;
    private float defaultMinNextWaveTime;
    private float defaultMaxNextWaveTime;

    private void Start()
    {
        spawnBossTimer = spawnBossCooldown;
        spawnEnemyTimer = 0;
        defaultMinNextWaveTime = minNextWaveTime;
        defaultMaxNextWaveTime = maxNextWaveTime;

        StartCoroutine(SpawnEnemyRoutine());
    }

    private void Update()
    {
        spawnBossTimer -= Time.deltaTime;
        spawnEnemyTimer -= Time.deltaTime;

        if (spawnBossTimer < 0)
        {
            SetupEnemyBoss();
        }

        if (spawnEnemyTimer < 0)
        {
            SetupSpawnEnemy();
        }
    }

    public WaveInfo GetCurrentWaveInfo()
    {
        return currentWave;
    }

    public void BossDead()
    {
        minNextWaveTime = defaultMinNextWaveTime;
        maxNextWaveTime = defaultMaxNextWaveTime;
        spawnBossTimer = spawnBossCooldown;
        isSpawnBoss = false;
        SetupSpawnEnemy();
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (isSpawnEnemy)
        {
            currentEnemyWave = enemyList[Random.Range(0, enemyList.Count)];
            currentWave = waveInfos[Random.Range(0, waveInfos.Count)];

            yield return new WaitForSeconds(GetRandomNextWaveTime());

            for (int i = 0; i < currentEnemyWave.GetCount(); i++)
            {
                GameObject newEnemy = Instantiate(currentEnemyWave.GetByIndex(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                RotateEnemy(newEnemy);

                yield return new WaitForSeconds(currentWave.GetRandomTimeSpawnEnemy());
            }
        }
    }

    private float GetRandomNextWaveTime()
    {
        return Random.Range(minNextWaveTime, maxNextWaveTime);
    }

    private void SetupSpawnEnemy()
    {
        if (isSpawnEnemy) return;

        StopCoroutine(SpawnEnemyRoutine());
        isSpawnEnemy = true;
        spawnEnemyTimer = 0;
        StartCoroutine(SpawnEnemyRoutine());
    }

    private void SetupEnemyBoss()
    {
        if (isSpawnBoss) return;

        if (bossPrefabList.GetCount() > 0)
        {
            spawnEnemyTimer = spawnEnemyCooldown;
            isSpawnEnemy = false;
            isSpawnBoss = true;
            minNextWaveTime += addNextWaveTime;
            maxNextWaveTime += addNextWaveTime;
            SpawnEnemyBoss();
        }
    }

    private void SpawnEnemyBoss()
    {
        GameObject bossPrefab = bossPrefabList.GetByIndex(Random.Range(0, bossPrefabList.GetCount()));
        GameObject newBoss = Instantiate(bossPrefab, transform);
        RotateEnemy(newBoss);
    }

    private void RotateEnemy(GameObject gameObject)
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, -180);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, -180);
    }
}
