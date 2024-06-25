using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button retryBtn;
    [SerializeField] private Button mainMenuBtn;

    private void Awake()
    {
        retryBtn.onClick.AddListener(() =>
        {
            Debug.Log("Retry");
        });

        mainMenuBtn.onClick.AddListener(() =>
        {
            Debug.Log("Return main menu");
        });
    }
}
