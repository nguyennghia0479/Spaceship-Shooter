using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button mainMenuBtn;

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

    private void Start()
    {
        /*scoreText.text = ScoreManager.Instance.GetScorePoint().ToString();*/
    }
}
