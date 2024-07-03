using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Slider vibration;
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button closeBtn;

    private PlayerController playerController;
    private LevelManager levelManager;
    private BackgroundUI backgroundUI;
    private CameraShake cameraShake;

    private void Awake()
    {
        levelManager = LevelManager.Instance;
        cameraShake = Camera.main.GetComponent<CameraShake>();
        if (cameraShake == null)
        {
            Debug.LogWarning("Camera Shake is null");
            return;
        }

        if (levelManager.IsGameScene())
        {
            InitButtonInGameScene();
        }
        else if (levelManager.IsMainMenuScene())
        {
            backgroundUI = FindAnyObjectByType<BackgroundUI>();
            if (backgroundUI == null)
            {
                Debug.Log("BackgroundUI is null.");
                return;
            }

            InitButtonInMainMenuScene();
        }

        InitVibrationSlider();
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

    private void InitButtonInGameScene()
    {
        DialogBoxUI dialogBoxUI = FindObjectOfType<DialogBoxUI>();
        if (dialogBoxUI == null)
        {
            Debug.LogWarning("DialogBoxUI is null.");
            return;
        }

        resumeBtn.onClick.AddListener(() =>
        {
            playerController.ToogleSetting();
        });

        mainMenuBtn.onClick.AddListener(() =>
        {
            dialogBoxUI.Show();
        });
    }

    private void InitButtonInMainMenuScene()
    {
        closeBtn.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    private void InitVibrationSlider()
    {
        vibration.minValue = 0;
        vibration.maxValue = .5f;

        if (cameraShake != null)
        {
            vibration.value = PlayerPrefs.GetFloat(cameraShake.GetShakeMagnitude(), .25f);
        }

        vibration.onValueChanged.AddListener(delegate
        {
            cameraShake.ChanageShakeMagnitude(vibration.value);
        });
    }

    public void Show()
    {
        gameObject.SetActive(true);

        if (levelManager.IsMainMenuScene())
        {
            backgroundUI.SetBackground(150, false);
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);

        if (levelManager.IsMainMenuScene())
        {
            backgroundUI.SetBackground(0, true);
        }
    }
}
