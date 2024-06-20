using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private ListPrefabInfo meteorPrefabs;
    [SerializeField] private float minTimeToSpawn;
    [SerializeField] private float maxTimeToSpawn;

    private CameraController cameraController;
    private readonly bool isSpawn = true;

    private void Start()
    {
        cameraController = GetComponent<CameraController>();
        if (cameraController == null )
        {
            Debug.LogWarning("Camera Controller is null.");
            return;
        }

        StartCoroutine(SpawnMeteorRoutine());
    }

    private IEnumerator SpawnMeteorRoutine()
    {
        while (isSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minTimeToSpawn, maxTimeToSpawn));

            GameObject randomMeteor = meteorPrefabs.GetByIndex(Random.Range(0, meteorPrefabs.GetCount()));
            Vector2 spawnPosition = SpawnPosition();
            Instantiate(randomMeteor, spawnPosition, Quaternion.identity, transform);
        }
    }

    private Vector2 SpawnPosition()
    {
        Vector2 minBound = cameraController.GetMinBound();
        Vector2 maxBound = cameraController.GetMaxBound();
        float paddingLeft = cameraController.GetPaddingLeft();
        float paddingRight = cameraController.GetPaddingRight();
        float paddingTop = cameraController.GetPaddingTop();

        float xPosition = Random.Range(minBound.x + paddingLeft, maxBound.x - paddingRight);
        float yPosition = maxBound.y + paddingTop;

        return new Vector2(xPosition, yPosition);
    }
}
