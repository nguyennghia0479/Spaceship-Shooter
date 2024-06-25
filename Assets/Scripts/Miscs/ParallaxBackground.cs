using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;

    private Material material;

    private void Awake()
    {
        material = GetComponentInChildren<SpriteRenderer>().material;
    }

    private void Update()
    {
        material.mainTextureOffset += moveSpeed * Time.deltaTime;
    }

    public void SetParallaxBackground(float moveX)
    {
        moveSpeed.x = moveX;
    }
}
