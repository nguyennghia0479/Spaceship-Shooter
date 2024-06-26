using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private LocalizedString localizedStringScore;

    private void Awake()
    {
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

    private void OnEnable()
    {
        int score = ScoreManager.Instance.GetScorePoint();
        localizedStringScore.Arguments = new object[] { score };
        localizedStringScore.StringChanged += UpdateText;
    }

    private void OnDisable()
    {
        localizedStringScore.StringChanged -= UpdateText;
    }

    private void UpdateText(string value)
    {
        scoreText.text = value;
    }
}
