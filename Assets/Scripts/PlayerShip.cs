using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private ParallaxBackground parallaxBackground;
    private PlayerController playerController;
    private CameraController cameraController;

    private void Start()
    {
        parallaxBackground = FindObjectOfType<ParallaxBackground>();
        playerController = GetComponent<PlayerController>();
        cameraController = GetComponent<CameraController>();
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
}
