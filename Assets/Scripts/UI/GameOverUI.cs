using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : UI
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button mainMenuBtn;

    private void Awake()
    {
        backgroundImage = background.GetComponent<Image>();
        DialogBoxUI dialogBoxUI = FindObjectOfType<DialogBoxUI>();
        if (dialogBoxUI == null)
        {
            Debug.LogWarning("DialogBoxUI is null.");
            return;
        }

        retryBtn.onClick.AddListener(() =>
        {
            LevelManager.Instance.LoadGameScene();
        });

        mainMenuBtn.onClick.AddListener(() =>
        {
            
            dialogBoxUI.Show();
        });
    }

    private void Start()
    {
        scoreText.text = ScoreManager.Instance.GetScorePoint().ToString();
    }

    public override void SetBackground(float alpha, bool isInteractable)
    {
        base.SetBackground(alpha, isInteractable);
    }
}
