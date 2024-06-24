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

    private SettingUI settingUI;
    private CustomUI customUI;

    private void Awake()
    {
        InitComponent();

        startBtn.onClick.AddListener(() =>
        {
            Debug.Log("Start game");
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
    }
}
