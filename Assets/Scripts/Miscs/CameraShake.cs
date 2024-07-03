using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration = .25f;

    private Vector3 defaultPos;
    private float shakeMagnitude = .5f;

    public const string SHAKE_MAGNITUDE = "ShakeMagnitude";

    private void Awake()
    {
        defaultPos = transform.position;
    }

    private void Start()
    {
        shakeMagnitude = PlayerPrefs.GetFloat(SHAKE_MAGNITUDE, .25f);
    }

    public void PlayCameraShake()
    {
        if (shakeMagnitude <= 0) return;

        StartCoroutine(CameraShakeRoutine());
    }

    public string GetShakeMagnitude()
    {
        return SHAKE_MAGNITUDE;
    }

    public void ChanageShakeMagnitude(float value)
    {
        shakeMagnitude = value;
        PlayerPrefs.SetFloat(SHAKE_MAGNITUDE, value);
        PlayerPrefs.Save();
    }

    private IEnumerator CameraShakeRoutine()
    {
        float elapseTime = 0;

        while (elapseTime < duration)
        {
            transform.position = defaultPos + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapseTime += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }

        transform.position = defaultPos;
    }
}
