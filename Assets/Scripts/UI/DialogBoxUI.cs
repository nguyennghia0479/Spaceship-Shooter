using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxUI : MonoBehaviour
{
    [SerializeField] private Button cancelBtn;
    [SerializeField] private Button okBtn;

    private UI ui;

    private void Awake()
    {
        ui = FindObjectOfType<UI>();
        if (ui == null)
        {
            Debug.Log("SettingUI is null");
            return;
        }

        cancelBtn.onClick.AddListener(() =>
        {
            Hide();
        });

        okBtn.onClick.AddListener(() =>
        {
            LevelManager.Instance.LoadMainMenuScene();
        });
    }

    private void Start()
    {
        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        ui.SetBackground(150f, false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        ui.SetBackground(0, true);
    }
}
