using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveInfo> waveInfos;
    [SerializeField] private float loopingTime;

    private WaveInfo currentWave;
    private readonly bool isSpawn = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    public WaveInfo GetCurrentWaveInfo()
    {
        return currentWave;
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        do
        {
            foreach (WaveInfo waveInfo in waveInfos)
            {
                currentWave = waveInfo;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyByIndex(i), currentWave.GetStartingWaypoint().position, Quaternion.Euler(0, 0, -180), transform);

                    yield return new WaitForSeconds(currentWave.GetRandomTimeSpawnEnemy());
                }

                yield return new WaitForSeconds(loopingTime);
            }
        } while (isSpawn);
    }
}
