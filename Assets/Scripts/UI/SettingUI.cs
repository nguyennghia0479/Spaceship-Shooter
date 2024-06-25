using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : UI
{
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button closeBtn;

    private PlayerController playerController;
    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = LevelManager.Instance;

        if (levelManager.IsGameScene())
        {
            backgroundImage = background.GetComponent<Image>();
            InitButtonInGameScene();
        }
        else if (levelManager.IsMainMenuScene())
        {
            InitButtonInMainMenuScene();
        }
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

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public override void SetBackground(float alpha, bool isInteractable)
    {
        base.SetBackground(alpha, isInteractable);
    }
}
