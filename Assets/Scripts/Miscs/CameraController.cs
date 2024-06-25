using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float paddingLeft;
    [SerializeField] private float paddingRight;
    [SerializeField] private float paddingTop;
    [SerializeField] private float paddingBottom;

    private Vector2 minBound;
    private Vector2 maxBound;

    private void Awake()
    {
        Camera camera = Camera.main;
        minBound = camera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = camera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    public Vector3 GetPositionInBoundary(Vector3 target, Vector3 delta)
    {
        Vector3 newPos = target + delta;
        newPos.x = Mathf.Clamp(newPos.x, minBound.x + paddingLeft, maxBound.x - paddingRight);
        newPos.y = Mathf.Clamp(newPos.y, minBound.y + paddingBottom, maxBound.y - paddingTop);

        return newPos;
    }

    public Vector2 GetMinBound()
    {
        return minBound;
    }

    public Vector2 GetMaxBound()
    {
        return maxBound;
    }

    public float GetPaddingLeft()
    {
        return paddingLeft;
    }

    public float GetPaddingRight()
    {
        return paddingRight;
    }

    public float GetPaddingTop()
    {
        return paddingTop;
    }
}
