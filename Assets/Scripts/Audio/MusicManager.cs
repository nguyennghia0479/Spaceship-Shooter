using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] private AudioClipInfo audioClipInfo;
    [Range(0f, 1f)]
    [SerializeField] private float audioVolume;

    private AudioSource audioSource;
    private int index = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.volume = audioVolume;
    }

    private void Start()
    {
        audioSource.clip = audioClipInfo.musicTracks[index];
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetNextMusicTrack();
            audioSource.Play();
        }
    }

    private AudioClip GetNextMusicTrack()
    {
        index++;
        if (index >= audioClipInfo.musicTracks.Length)
        {
            index++;
        }

        return audioClipInfo.musicTracks[index];
    }
}
