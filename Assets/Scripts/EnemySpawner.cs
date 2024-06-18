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
        StartCoroutine(SpawnEnemy());
    }

    public WaveInfo GetCurrentWaveInfo()
    {
        return currentWave;
    }

    private IEnumerator SpawnEnemy()
    {
        do
        {
            foreach (WaveInfo waveInfo in waveInfos)
            {
                currentWave = waveInfo;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyByIndex(i), currentWave.GetStartingWaypoint().position, Quaternion.identity);

                    yield return new WaitForSeconds(currentWave.GetRandomTimeSpawnEnemy());
                }

                yield return new WaitForSeconds(loopingTime);
            }
        } while (isSpawn);
    }
}
