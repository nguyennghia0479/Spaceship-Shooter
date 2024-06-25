using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private ParallaxBackground parallaxBackground;
    private PlayerController playerController;
    private CameraController cameraController;
    private float defaultMoveSpeed;

    private void Start()
    {
        parallaxBackground = FindObjectOfType<ParallaxBackground>();
        if (parallaxBackground == null )
        {
            Debug.LogWarning("Parallax Background is null.");
            return;
        }

        playerController = GetComponent<PlayerController>();
        if (playerController == null )
        {
            Debug.LogWarning("Player Controller is null.");
            return;
        }

        cameraController = GetComponent<CameraController>();
        if (cameraController == null)
        {
            Debug.LogWarning("Camera Controller is null.");
            return;
        }

        defaultMoveSpeed = moveSpeed;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 delta = moveSpeed * Time.deltaTime * playerController.GetMovementNormalized();
        Vector3 newPos = cameraController.GetPositionInBoundary(transform.position, delta);
        transform.position = newPos;
        parallaxBackground.SetParallaxBackground(delta.x);
    }

    #region Buff stats
    public void IncreaseSpeed(float speedPercentage, float duration)
    {
        StartCoroutine(IncreaseSpeedRoutine(speedPercentage, duration));
    }

    private IEnumerator IncreaseSpeedRoutine(float speedPercentage, float duration)
    {
        moveSpeed += moveSpeed * speedPercentage;

        yield return new WaitForSeconds(duration);

        moveSpeed = defaultMoveSpeed;
    }

    public void AddShieldGuard(GameObject shieldPrefab, float duration)
    {
        GameObject newShield = Instantiate(shieldPrefab, transform.position, Quaternion.identity, transform);
        Destroy(newShield, duration);
    }

    #endregion
}
