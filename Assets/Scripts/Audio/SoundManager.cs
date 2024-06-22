using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipInfo audioClipInfo;
    [Range(0f, 1f)]
    [SerializeField] private float audioVolume;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayExecuteItemSound()
    {
        PlaySound(audioClipInfo.executeItems, Camera.main.transform.position, audioVolume);
    }

    public void PlayMeteorExplosionSound(Vector3 position)
    {
        PlaySound(audioClipInfo.meteorExplosion, position, audioVolume);
    }

    public void PlayShipExplosionSound(Vector3 position)
    {
        PlaySound(audioClipInfo.shipExplosions, position, audioVolume);
    }

    public void PlayShootLaserLarge(Vector3 position)
    {
        PlaySound(audioClipInfo.laserLarges, position, audioVolume);
    }

    public void PlayShootLaserSmall(Vector3 position)
    {
        PlaySound(audioClipInfo.laserSmalls, position, audioVolume);
    }

    private void PlaySound(AudioClip[] audioClips, Vector3 position, float volume)
    {
        if (audioClips == null || audioClips.Length == 0)
        {
            Debug.LogWarning("No audio clips provided to play.");
            return;
        }

        AudioSource.PlayClipAtPoint(audioClips[Random.Range(0, audioClips.Length)], position, volume);
    }
}
