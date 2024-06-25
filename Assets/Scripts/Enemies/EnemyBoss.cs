using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Prepare, Shooter
}

public class EnemyBoss : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float timeToMove = 0;
    [SerializeField] private Transform pathBoss;

    private CameraController cameraController;
    private Vector2 moveDir;
    private EnemyState enemyState = EnemyState.Prepare;
    private int waypointIndex = 1;

    private void Start()
    {
        cameraController = GetComponent<CameraController>();
        if (cameraController == null)
        {
            Debug.LogWarning("Camera Controller is null. Destroy game object");
            Destroy(gameObject);
            return;
        }

        transform.position = pathBoss.GetChild(0).transform.position;
        StartCoroutine(MoveRoutine());
    }

    private void Update()
    {
        if (enemyState == EnemyState.Shooter)
        {
            HandleMove();
        }
        else
        {
            HandlePrepareToBattle();
        }
    }

    private void HandleMove()
    {
        Vector3 delta = moveSpeed * Time.deltaTime * moveDir;
        Vector3 newPos = cameraController.GetPositionInBoundary(transform.position, delta);
        transform.position = newPos;

    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            moveDir = GetMoveDirNormalized();

            yield return new WaitForSeconds(timeToMove);
        }
    }

    private Vector2 GetMoveDirNormalized()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void HandlePrepareToBattle()
    {
        if (waypointIndex < pathBoss.childCount)
        {
            Vector3 targetPos = pathBoss.GetChild(waypointIndex).position;
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                waypointIndex++;
            }
        }
        else
        {
            enemyState = EnemyState.Shooter;
        }
    }

    public EnemyState GetEnemyState()
    {
        return enemyState;
    }
}
