using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private WaveInfo waveInfo;
    private List<Transform> waypoints;
    private int index;

    private void Start()
    {
        enemySpawner = GetComponentInParent<EnemySpawner>();
        if (enemySpawner == null)
        {
            Debug.LogWarning("Enemy spawner is null. Destroy game object!");
            Destroy(gameObject);
            return;
        }

        waveInfo = enemySpawner.GetCurrentWaveInfo();
        if (waveInfo == null)
        {
            Debug.LogWarning("Wave info is null. Destroy game object!");
            Destroy(gameObject);
            return;
        }

        waypoints = waveInfo.GetWaypoints();
        index = 1;
    }

    private void Update()
    {
        FindingPath();
    }

    private void FindingPath()
    {
        if (index < waypoints.Count)
        {
            Vector3 targetPos = waypoints[index].position;
            float step = waveInfo.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                index++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
