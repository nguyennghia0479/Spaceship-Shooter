using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxUI : MonoBehaviour
{
    [SerializeField] private Button cancelBtn;
    [SerializeField] private Button okBtn;

    private BackgroundUI backgroundUI;

    private void Awake()
    {
        backgroundUI = FindAnyObjectByType<BackgroundUI>();
        if (backgroundUI == null)
        {
            Debug.Log("BackgroundUI is null.");
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
        backgroundUI.SetBackground(150, false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        backgroundUI.SetBackground(0, true);
    }
}
