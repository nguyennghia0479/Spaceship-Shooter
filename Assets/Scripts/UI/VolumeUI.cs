using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;
    [SerializeField] private string parameter;
    [SerializeField] private float multiplier = 30;

    private void Awake()
    {
        slider.onValueChanged.AddListener(delegate
        {
            audioMixer.SetFloat(parameter, Mathf.Log10(slider.value) * multiplier);
        });
    }
}
