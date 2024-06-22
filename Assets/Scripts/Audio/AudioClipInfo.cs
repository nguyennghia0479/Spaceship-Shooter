using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio Clip Info")]
public class AudioClipInfo : ScriptableObject
{
    public AudioClip[] musicTracks;
    public AudioClip[] laserLarges;
    public AudioClip[] laserSmalls;
    public AudioClip[] shipExplosions;
    public AudioClip[] meteorExplosion;
    public AudioClip[] executeItems;
}
