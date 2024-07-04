using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button customBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private Button creditBtn;

    private SettingUI settingUI;
    private CustomUI customUI;
    private CreditUI creditUI;

    private void Awake()
    {
        InitComponent();

        startBtn.onClick.AddListener(() =>
        {
            LevelManager.Instance.LoadGameScene();
        });

        customBtn.onClick.AddListener(() =>
        {
            customUI.Show();
        });

        settingBtn.onClick.AddListener(() =>
        {
            settingUI.Show();
        });

        quitBtn.onClick.AddListener(() =>
        {
            Debug.Log("Quit");
            Application.Quit();
        });

        creditBtn.onClick.AddListener(() =>
        {
            creditUI.Show();
        });

        Time.timeScale = 1f;
    }

    private void InitComponent()
    {
        settingUI = FindObjectOfType<SettingUI>();
        if (settingUI == null)
        {
            Debug.Log("SettingUI is null.");
            return;
        }

        customUI = FindObjectOfType<CustomUI>();
        if (customUI == null)
        {
            Debug.Log("CustomUI is null.");
            return;
        }

        creditUI = FindObjectOfType<CreditUI>();
        if (creditUI == null)
        {
            Debug.Log("CreditUi is null.");
            return;
        }
    }
}
