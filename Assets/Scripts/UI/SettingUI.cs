using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private float multiplier;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button mainMenuBtn;

    private PlayerController playerController;

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(delegate {
            audioMixer.SetFloat("bgm", Mathf.Log10(musicSlider.value) * multiplier);
        });

        soundSlider.onValueChanged.AddListener(delegate {
            audioMixer.SetFloat("sfx", Mathf.Log10(soundSlider.value) * multiplier);
        });

        resumeBtn.onClick.AddListener(() =>
        {
            playerController.ToogleSetting();
        });

        mainMenuBtn.onClick.AddListener(() =>
        {
            Debug.Log("Return main menu");
        });
    }

    private void OnEnable()
    {
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogWarning("Player Controller is null.");
            return;
        }

        playerController.OnToogleSetting += PlayerController_OnToogleSetting;
    }

    private void Start()
    {
        Hide();
    }

    private void OnDestroy()
    {
        if (playerController != null)
        {
            playerController.OnToogleSetting -= PlayerController_OnToogleSetting;
        }
    }

    private void PlayerController_OnToogleSetting(bool isOpenSetting)
    {
        if (isOpenSetting)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
