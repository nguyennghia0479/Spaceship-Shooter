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
        material.mainTextureOffset += new Vector2(moveSpeed.x, moveSpeed.y * Time.deltaTime);
    }
}
