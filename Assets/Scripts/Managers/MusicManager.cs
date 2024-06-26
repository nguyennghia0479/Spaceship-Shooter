using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    [SerializeField] private List<AudioSource> musicSources;
    private int currentTrackIndex = 0;

    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMusicTrack(currentTrackIndex);
    }

    private void Update()
    {
        if (!musicSources[currentTrackIndex].isPlaying)
        {
            PlayNextMusic();
        }
    }

    private void PlayNextMusic()
    {
        currentTrackIndex++;
        if (currentTrackIndex >= musicSources.Count)
            currentTrackIndex = 0;

        PlayMusicTrack(currentTrackIndex);
    }

    private void PlayMusicTrack(int index)
    {
        if (musicSources.Count <= 0) return;

        foreach (var audioSource in musicSources)
        {
            audioSource.Stop();
        }

        musicSources[index].Play();

    }
}
