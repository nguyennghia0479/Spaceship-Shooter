using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;
    [SerializeField] private string parameter;
    [SerializeField] private float multiplier = 30;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(parameter, 0.5f);

        SetVolume(slider.value);

        slider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat(parameter, Mathf.Log10(sliderValue) * multiplier);

        PlayerPrefs.SetFloat(parameter, sliderValue);
        PlayerPrefs.Save();
    }
}
