using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveInfo> waveInfos;
    [SerializeField] private float loopingTime;
    [Space]
    [Header("Boss")]
    [SerializeField] private List<GameObject> bossPrefabList;
    [SerializeField] private int maxWaveToSpawnBoss = 2;

    private WaveInfo currentWave;
    private int waveCount = 0;
    private bool isSpawnEnemy = true;
    private bool isSpawnBoss = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    public WaveInfo GetCurrentWaveInfo()
    {
        return currentWave;
    }

    public void SetupSpawnEnemy()
    {
        isSpawnEnemy = true;
        StartCoroutine(SpawnEnemyRoutine());
    }

    public void BossDead()
    {
        isSpawnBoss = true;
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (isSpawnEnemy)
        {
            foreach (WaveInfo waveInfo in waveInfos)
            {
                currentWave = waveInfo;

                yield return new WaitForSeconds(loopingTime);

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyByIndex(i), currentWave.GetStartingWaypoint().position, Quaternion.Euler(0, 0, -180), transform);

                    yield return new WaitForSeconds(currentWave.GetRandomTimeSpawnEnemy());
                }

                SetupEnemyBoss();
            }
        }
    }

    private void SetupEnemyBoss()
    {
        if (!isSpawnBoss) return;

        waveCount++;
        if (bossPrefabList.Count > 0 && waveCount >= maxWaveToSpawnBoss)
        {
            waveCount = 0;
            isSpawnEnemy = false;
            isSpawnBoss = false;
            SpawnEnemyBoss();
        }
    }

    private void SpawnEnemyBoss()
    {
        GameObject bossPrefab = bossPrefabList[0];
        GameObject newBoss = Instantiate(bossPrefab, transform);
        newBoss.GetComponentInChildren<SpriteRenderer>().transform.rotation = Quaternion.Euler(0, 0, -180);
        newBoss.transform.rotation = Quaternion.Euler(0, 0, -180);

        bossPrefabList.Remove(bossPrefab);
    }
}
