using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource[] laserLarges;
    [SerializeField] private AudioSource[] laserSmalls;
    [SerializeField] private AudioSource[] shipExplosions;
    [SerializeField] private AudioSource[] meteorExplosion;
    [SerializeField] private AudioSource[] executedItems;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayExecuteItemSound()
    {
        PlaySound(executedItems, Camera.main.transform.position);
    }

    public void PlayMeteorExplosionSound(Vector3 position)
    {
        PlaySound(meteorExplosion, position);
    }

    public void PlayShipExplosionSound(Vector3 position)
    {
        PlaySound(shipExplosions, position);
    }

    public void PlayShootLaserLarge(Vector3 position)
    {
        PlaySound(laserLarges, position);
    }

    public void PlayShootLaserSmall(Vector3 position)
    {
        PlaySound(laserSmalls, position);
    }

    private void PlaySound(AudioSource[] audioSources, Vector3 position)
    {
        if (audioSources == null || audioSources.Length == 0)
        {
            Debug.LogWarning("No audio sources provided to play.");
            return;
        }

        AudioSource audioSource = audioSources[Random.Range(0, audioSources.Length)];
        audioSource.Stop();
        audioSource.transform.position = position;
        audioSource.Play();
    }
}
