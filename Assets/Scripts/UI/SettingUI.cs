using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Button resumeBtn;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private Button closeBtn;

    private PlayerController playerController;

    private void Awake()
    {
        if (resumeBtn != null)
        {
            resumeBtn.onClick.AddListener(() =>
            {
                playerController.ToogleSetting();
            });
        }

        if (mainMenuBtn != null)
        {
            mainMenuBtn.onClick.AddListener(() =>
            {
                Debug.Log("Return main menu");
            });
        }

        if (closeBtn != null)
        {
            closeBtn.onClick.AddListener(() =>
            {
                Hide();
            });
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

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
