using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Info")]
public class WaveInfo : ScriptableObject
{
    [SerializeField] private Transform path;
    [SerializeField] private List<Transform> enemies;
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;
    [SerializeField] private float moveSpeed;

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new();

        foreach (Transform waypoint in path)
        {
            waypoints.Add(waypoint);
        }

        return waypoints;
    }

    public Transform GetStartingWaypoint()
    {
        return path.GetChild(0).transform;
    }

    public float GetRandomTimeSpawnEnemy()
    {
        return Random.Range(minTime, maxTime);
    }

    public Transform GetEnemyByIndex(int index)
    {
        return enemies[index];
    }

    public int GetEnemyCount()
    {
        return enemies.Count;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
